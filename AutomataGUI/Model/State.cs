using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace AutomataGUI.Model
{
    public sealed class State : Drawable
    {
        #region Fields

        public bool IsEndState
        {
            get { return _isEndState; }
            set { _isEndState = value; }
        }
        private bool _isEndState;

        public bool IsStartState
        {
            get { return _isStartState; }
            set { _isStartState = value; }
        }
        private bool _isStartState;

        #endregion

        #region Methods

        public override void Draw(Graphics graphics, int scrollOffsetX, int scrollOffsetY)
        {
            RectangleF newRectangle = _rectangle;
            newRectangle.X += scrollOffsetX;
            newRectangle.Y += scrollOffsetY;

            graphics.FillEllipse(Brushes.White, newRectangle);

            graphics.DrawEllipse((_isSelected ? Pens.Red : Pens.Black), newRectangle);

            if (_isEndState)
            {
                graphics.DrawEllipse((_isSelected ? Pens.Red : Pens.Black), 
                    new RectangleF(newRectangle.X + 2, newRectangle.Y + 2,
                    newRectangle.Width - 4, newRectangle.Height - 4));
            }

            SizeF textSize = graphics.MeasureString(_label, _controlFont);

            float textX = newRectangle.X + (newRectangle.Width / 2f) - (textSize.Width / 2f);
            float textY = newRectangle.Y + (newRectangle.Height / 2f) - (textSize.Height / 2f);

            graphics.DrawString(_label, _controlFont, 
                (_isSelected ? Brushes.Red : Brushes.Black), 
                new PointF(textX, textY));

            if (_isStartState)
            {
                float underlineY = newRectangle.Y + (newRectangle.Height / 2f) + (textSize.Height / 2f);
                graphics.DrawLine((_isSelected ? Pens.Red : Pens.Black), 
                    textX, underlineY, textX + textSize.Width - 1, underlineY);
            }
        }

        public override string GenerateXml()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Statics.Space4}<state>");
            stringBuilder.AppendLine($"{Statics.Space8}<id>{_id}</id>");
            stringBuilder.AppendLine($"{Statics.Space8}<x>{_rectangle.X}</x>");
            stringBuilder.AppendLine($"{Statics.Space8}<y>{_rectangle.Y}</y>");
            stringBuilder.AppendLine($"{Statics.Space8}<label>{_label}</label>");
            stringBuilder.AppendLine($"{Statics.Space8}<start>{_isStartState}</start>");
            stringBuilder.AppendLine($"{Statics.Space8}<end>{_isEndState}</end>");
            stringBuilder.AppendLine($"{Statics.Space4}</state>");

            return stringBuilder.ToString();
        }

        public void MouseMove(Point position, MouseButtons mouseButtons)
        {
            if (mouseButtons != MouseButtons.Left)
            {
                return;
            }

            Rectangle = new RectangleF(
                position.X - (Rectangle.Width / 2),
                position.Y - (Rectangle.Height / 2), 
                Rectangle.Width, 
                Rectangle.Height);
        }

        #endregion
    }
}
