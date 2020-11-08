using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using AutomataGUI.Model;
using AutomataGUI.Properties;
using AutomataGUI.LoadSave;

namespace AutomataGUI.View
{
    public partial class MainWindow : Form
    {
        #region Fields

        private Drawable _selectedDrawable;
        private State _selectedState;
        private StateMachine _manager = new StateMachine();

        private readonly Random _random = new Random();

        private bool _transitionMode = false;
        private int _idx = 0;
        private int _scrollOffsetX = 0;
        private int _scrollOffsetY = 0;

        //private Point _mouseClick;

        #endregion

        #region Methods

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            DoubleBuffered = true;

#if DEBUG
            debugToolStripMenuItem.Visible = true;
#else
            debugToolStripMenuItem.Visible = false;
#endif
        }

        private void ToolboxListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (toolboxListView.SelectedItems.Count == 0) return;

            if (toolboxListView.SelectedItems[0].Text == @"Transition")
            {
                _transitionMode = true;
                toolStripStatusLabelLeft.Text = Resources.StatusTransitionMode;
                Cursor = Cursors.Cross;

                return;
            }

            State newState = new State
            {
                Id = _idx,
                Label = _idx.ToString()
            };
            SetStateParameters(newState);

            int pos = 100 + (_idx * 20);

            _manager.AddState(_idx, pos, pos, newState);

            panelRendering.Invalidate();

            _idx++;

            UpdateStatusBar();
        }        

        private void TextBoxLabel_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ButtonApply_Click(sender, new EventArgs());
            }
        }

        #region Rendering panel

        private void PanelRendering_Paint(object sender, PaintEventArgs e)
        {
            foreach (Drawable drawable in _manager.Drawables)
            {
                drawable.Draw(e.Graphics, _scrollOffsetX, _scrollOffsetY);
            }
        }

        private void PanelRendering_MouseDown(object sender, MouseEventArgs e)
        {
            // _mouseClick = e.Location;

            if (_selectedDrawable != null)
            {
                _selectedDrawable.IsSelected = false;
                _selectedDrawable = null;
            }

            foreach (Drawable drawable in _manager.Drawables)
            {
                if (drawable.Rectangle.Contains(Point.Add(e.Location, new Size(_scrollOffsetX, _scrollOffsetY))))
                {
                    _selectedDrawable = drawable;
                }
            }

            DisableStateSettings();
            DisableTransitionSettings();

            if (_selectedDrawable != null)
            {
                _selectedDrawable.IsSelected = true;

                if (_selectedDrawable is State state)
                {
                    EnableStateSettings();

                    if (_transitionMode)
                    {
                        if (_selectedState == null)
                        {
                            _selectedState = state;
                        }
                        else
                        {
                            _manager.AddTransition(_selectedState, state, _idx);
                            _idx++;

                            _selectedState = null;
                            _transitionMode = false;
                            toolStripStatusLabelLeft.Text = Resources.StatusReady;
                            Cursor = Cursors.Arrow;
                        }
                    }
                    else
                    {
                        textBoxLabel.Text = state.Label;
                        checkBoxStart.Checked = state.IsStartState;
                        checkBoxEnd.Checked = state.IsEndState;
                    }
                }
                else if (_selectedDrawable is Transition transition)
                {
                    EnableTransitionSettings();
                    textBoxLabel.Text = transition.Label;
                }
            }

            panelRendering.Invalidate();
        }

        private void PanelRendering_MouseMove(object sender, MouseEventArgs e)
        {
            if (_selectedDrawable is State state)
            {
                PointF oldPos = state.Center;

                RectangleF oldRectF = state.Rectangle;

                state.MouseMove(e.Location, e.Button);

                if (oldPos != state.Center)
                {
                    panelRendering.Invalidate(RoundRectangle(oldRectF));
                    panelRendering.Invalidate(RoundRectangle(state.Rectangle));
                }
            }
        }

        private void PanelRendering_MouseUp(object sender, MouseEventArgs e)
        {
            panelRendering.Invalidate();
        }

        #region Scrolling

        private void VerticalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            /*int diff = (e.OldValue - e.NewValue) * 10;
            _scrollOffsetY += diff;

            panelRendering.Invalidate();*/
        }

        private void HorizontalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            /*int diff = (e.OldValue - e.NewValue) * 10;
            _scrollOffsetX += diff;

            panelRendering.Invalidate();*/
        }

        private void ScrollVertical(Direction direction)
        {
            int oldScroll = verticalScrollBar.Value;

            if (direction == Direction.Decrement)
            {
                if (verticalScrollBar.Value > 0)
                {
                    verticalScrollBar.Value -= verticalScrollBar.LargeChange;
                }
                else
                {
                    verticalScrollBar.Value = 0;
                }
            }
            else
            {
                if (verticalScrollBar.Value < verticalScrollBar.Maximum - verticalScrollBar.LargeChange)
                {
                    verticalScrollBar.Value += verticalScrollBar.LargeChange;
                }
                else
                {
                    verticalScrollBar.Value = verticalScrollBar.Maximum;
                }
            }

            VerticalScrollBar_Scroll(verticalScrollBar,
                new ScrollEventArgs(ScrollEventType.LargeDecrement,
                    oldScroll,
                    verticalScrollBar.Value,
                    ScrollOrientation.VerticalScroll)
            );
        }

        private void ScrollHorizontal(Direction direction)
        {
            int oldScroll = horizontalScrollBar.Value;

            if (direction == Direction.Decrement)
            {
                if (horizontalScrollBar.Value > verticalScrollBar.LargeChange)
                {
                    horizontalScrollBar.Value -= verticalScrollBar.LargeChange;
                }
                else
                {
                    horizontalScrollBar.Value = 0;
                }
            }
            else
            {
                if (horizontalScrollBar.Value < horizontalScrollBar.Maximum - verticalScrollBar.LargeChange)
                {
                    horizontalScrollBar.Value += verticalScrollBar.LargeChange;
                }
                else
                {
                    horizontalScrollBar.Value = horizontalScrollBar.Maximum;
                }
            }

            HorizontalScrollBar_Scroll(horizontalScrollBar,
                new ScrollEventArgs(ScrollEventType.LargeDecrement,
                    oldScroll,
                    horizontalScrollBar.Value,
                    ScrollOrientation.HorizontalScroll)
            );
        }

        #endregion

        private Rectangle RoundRectangle(RectangleF rectangleF)
        {
            int x = (int)rectangleF.X - 5;
            int y = (int)rectangleF.Y - 5;

            int width = (int)rectangleF.X + 5;
            int height = (int)rectangleF.Y + 5;

            return new Rectangle(x, y, width, height);
        }

        #endregion

        #region Export/Import

        private void ExportAsPNG_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog() { Filter = "PNG Files|*.png" })
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    if (_selectedDrawable != null)
                    {
                        _selectedDrawable.IsSelected = false;
                        _selectedDrawable = null;
                    }

                    Export.ExportAsPng(_manager, saveFile.FileName);
                }
            }
        }

        private void ExportAsXML_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = @"XML Files|*.xml" })
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                IO.WriteAutomata(saveFileDialog.FileName, 
                    new IOData(_manager, _idx, horizontalScrollBar.Value, verticalScrollBar.Value));
            }
        }

        private void ImportFromXML_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.Drawables.Clear();
                DisableStateSettings();
                DisableTransitionSettings();

                using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = @"XML Files|*.xml" })
                {
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    IOData data = IO.LoadAutomata(openFileDialog.FileName);

                    _manager = data.Manager;
                    horizontalScrollBar.Value = data.ScrollX;
                    verticalScrollBar.Value = data.ScrollY;
                    _idx = data.IdX;
                }

                panelRendering.Invalidate();
            }
            catch (Exception ex)
            {
                HandleImportError();

                MessageBox.Show(ex.Message);
            }
        }

        private void ExportAsLatex_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog() { Filter = "Tex Files|*.tex" })
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    if (_selectedDrawable != null)
                    {
                        _selectedDrawable.IsSelected = false;
                        _selectedDrawable = null;
                    }

                    Export.ExportAsLatex(_manager, saveFile.FileName);
                }
            }
        }

        private void HandleImportError()
        {
            _manager.Drawables.Clear();
            DisableStateSettings();
            DisableTransitionSettings();
        }

        #endregion

        #region View

        private void CenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int oldScrollY = verticalScrollBar.Value;
            verticalScrollBar.Value = 0;

            VerticalScrollBar_Scroll(verticalScrollBar,
                new ScrollEventArgs(ScrollEventType.LargeDecrement,
                    oldScrollY,
                    verticalScrollBar.Value,
                    ScrollOrientation.VerticalScroll)
            );

            int oldScrollX = horizontalScrollBar.Value;
            horizontalScrollBar.Value = 0;

            HorizontalScrollBar_Scroll(horizontalScrollBar,
                new ScrollEventArgs(ScrollEventType.LargeDecrement,
                    oldScrollX,
                    horizontalScrollBar.Value,
                    ScrollOrientation.HorizontalScroll)
            );
        }

        #endregion

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _manager.Reorder();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                {
                    _transitionMode = false;
                    toolStripStatusLabelLeft.Text = Resources.StatusReady;
                    Cursor = Cursors.Arrow;

                    break;
                }
                case Keys.Left:
                {
                    ScrollHorizontal(Direction.Decrement);
                    break;
                }
                case Keys.Right:
                {
                    ScrollHorizontal(Direction.Increment);
                    break;
                }
                case Keys.Up:
                {
                    ScrollVertical(Direction.Decrement);
                    break;
                }
                case Keys.Down:
                {
                    ScrollVertical(Direction.Increment);
                    break;
                }
                default:
                {
                    // ignore every other key
                    break;
                }
            }
        }
        
        private void SetStateParameters(State state)
        {
            switch (toolboxListView.SelectedItems[0].Text)
            {
                case "State":
                {
                    state.Type = StateType.Regular;
                    break;
                }
                case "StartState":
                {
                    state.Type = StateType.Start;
                    break;
                }
                case "EndState":
                {
                    state.Type = StateType.End;
                    break;
                }
                default:
                { 
                    throw new NotImplementedException();
                }
            }
        }

        #region GUI Util

        private void DisableStateSettings()
        {
            textBoxLabel.Enabled = false;
            textBoxLabel.Clear();

            checkBoxStart.Enabled = false;
            checkBoxEnd.Enabled = false;

            buttonApply.Enabled = false;
            buttonCancel.Enabled = false;
            buttonDelete.Enabled = false;

            checkBoxStart.Checked = false;
            checkBoxEnd.Checked = false;
        }

        private void DisableTransitionSettings()
        {
            textBoxLabel.Enabled = false;
            textBoxLabel.Clear();

            buttonApply.Enabled = false;
            buttonCancel.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private void EnableStateSettings()
        {
            textBoxLabel.Enabled = true;
            checkBoxStart.Enabled = true;
            checkBoxEnd.Enabled = true;

            buttonApply.Enabled = true;
            buttonCancel.Enabled = true;
            buttonDelete.Enabled = true;
        }

        private void EnableTransitionSettings()
        {
            textBoxLabel.Enabled = true;

            buttonApply.Enabled = true;
            buttonCancel.Enabled = true;
            buttonDelete.Enabled = true;
        }

        private void UpdateStatusBar()
        {
            toolStripStatusLabelStateCount.Text =
                _manager.StateCount == 1 ? "1 State" : $"{_manager.StateCount} States";

            toolStripStatusLabelTransitionCount.Text =
                _manager.TransitionCount == 1 ? "1 Transition" : $"{_manager.TransitionCount} Transitions";
        }

        #endregion

        #endregion

        #region Debug

        private void ToggleDebugRenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statics.Debug = !Statics.Debug;

            panelRendering.Invalidate();
        }

        private void LogToConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float maxX = float.MinValue;
            float maxY = float.MinValue;
            float minX = float.MaxValue;
            float minY = float.MaxValue;

            foreach (Drawable drawable in (from d in _manager.Drawables where (d is State) select d))
            {
                if (drawable.Rectangle.X < minX)
                {
                    minX = drawable.Rectangle.X - 5;
                }
                else if (drawable.Rectangle.X > maxX)
                {
                    maxX = drawable.Rectangle.X + 5;
                }

                if (drawable.Rectangle.Y < minY)
                {
                    minY = drawable.Rectangle.Y - 5;
                }
                else if (drawable.Rectangle.Y > maxY)
                {
                    maxY = drawable.Rectangle.Y + 5;
                }
            }

            int width = (int)(maxX - minX) + 100;
            int height = (int)(maxY - minY) + 100;

            Console.WriteLine($"minX:   {minX}");
            Console.WriteLine($"maxX:   {maxX}");
            Console.WriteLine($"minY:   {minY}");
            Console.WriteLine($"maxY:   {maxY}");

            Console.WriteLine($"width:  {width}");
            Console.WriteLine($"height: {height}");

            foreach (Drawable drawable in _manager.Drawables)
            {
                if (drawable is State)
                {
                    Console.WriteLine($"{drawable.Id}: {drawable.Center}");
                }
            }
        }

        #endregion

        #region Buttons

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            if (textBoxLabel.TextLength == 0)
            {
                MessageBox.Show(Resources.EmptyLabelError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxLabel.Focus();

                return;
            }

            if (_selectedDrawable is State state)
            {
                state.Label = textBoxLabel.Text;
                state.IsStartState = checkBoxStart.Checked;
                state.IsEndState = checkBoxEnd.Checked;
            }
            else if (_selectedDrawable is Transition transition)
            {
                transition.Label = textBoxLabel.Text;
            }

            panelRendering.Invalidate();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (_selectedDrawable is State state)
            {
                textBoxLabel.Text = state.Label;
                checkBoxStart.Checked = state.IsStartState;
                checkBoxEnd.Checked = state.IsEndState;
            }
            else if (_selectedDrawable is Transition transition)
            {
                textBoxLabel.Text = transition.Label;
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_selectedDrawable is State state)
            {
                DisableStateSettings();

                foreach (Transition transition in _manager.FindTransitions(state))
                {
                    _manager.Drawables.Remove(transition);
                }

                _manager.Drawables.Remove(_selectedDrawable);
                _selectedDrawable = null;

                UpdateStatusBar();
            }
            else if (_selectedDrawable is Transition)
            {
                _manager.Drawables.Remove(_selectedDrawable);

                UpdateStatusBar();
            }

            panelRendering.Invalidate();
        }

        #endregion

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimulateWindow window = new SimulateWindow(_manager);
            window.Show();
        }
    }
}