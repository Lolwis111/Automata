using AutomataGUI.Model;
using System;
using System.Windows.Forms;
using System.Linq;

namespace AutomataGUI.View
{
    public partial class SimulateWindow : Form
    {
        public event WordSelectedHandler WordSelected;

        private StateMachine _stateMachine;

        public SimulateWindow(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;

            InitializeComponent();
        }

        private void Simulate_Load(object sender, EventArgs e)
        {
            labelResult.MaximumSize = new System.Drawing.Size(Size.Width - 50, 0);
        }

        private void ButtonSimulate_Click(object sender, EventArgs e)
        {
            string word = textBoxWord.Text;

            try
            {
                bool result = _stateMachine.Evaluate(word);

                labelResult.ForeColor = System.Drawing.Color.Black;
                labelResult.Text = "Result: ";

                if (result)
                {
                    labelResult.Text += $"'{word}' was accepted.";
                    labelResult.ForeColor = System.Drawing.Color.Green;
                    listViewResults.Items.Add(new ListViewItem(new string[] { word, "Yes" }));
                }
                else
                {
                    labelResult.Text += $"'{word}' was not accepted.";
                    labelResult.ForeColor = System.Drawing.Color.Red;
                    listViewResults.Items.Add(new ListViewItem(new string[] { word, "No" }));
                }
            }
            catch(Exception ex)
            {
                labelResult.Text = $"Exception: {ex.Message}";
                labelResult.ForeColor = System.Drawing.Color.Red;

                listViewResults.Items.Add(new ListViewItem(new string[] { word, "Exception" }));
            }
        }

        private void SimulateWindow_SizeChanged(object sender, EventArgs e)
        {

            labelResult.MaximumSize = new System.Drawing.Size(Size.Width - 50, 0);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            listViewResults.Items.Clear();
        }

        private void listViewResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listViewResults.SelectedItems.Count > 0)
            {
                WordSelected?.Invoke(this, new WordSelectedEventArgs(listViewResults.SelectedItems[0].SubItems[0].Text));
            }
        }
    }
}
