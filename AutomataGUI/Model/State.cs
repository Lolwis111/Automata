using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace AutomataGUI.Model
{
    public sealed class State : Drawable
    {
        #region Fields

        public StateType Type { get; set; }

        public bool IsEndState
        {
            get
            {
                return (Type == StateType.End || Type == StateType.StartEnd);
            }
            set
            {
                if (value)
                {
                    switch (Type)
                    {
                        case StateType.End:
                        case StateType.Regular:
                            Type = StateType.End;
                            break;
                        case StateType.Start:
                        case StateType.StartEnd:
                            Type = StateType.StartEnd;
                            break;
                    }
                }
                else
                {
                    switch (Type)
                    {
                        case StateType.End:
                        case StateType.Regular:
                            Type = StateType.Regular;
                            break;
                        case StateType.Start:
                        case StateType.StartEnd:
                            Type = StateType.Start;
                            break;
                    }
                }
            }
        }

        public bool IsStartState
        {
            get
            {
                return (Type == StateType.Start || Type == StateType.StartEnd);
            }
            set
            {
                if (value)
                {
                    switch (Type)
                    {
                        case StateType.End:
                        case StateType.StartEnd:
                            Type = StateType.StartEnd;
                            break;
                        case StateType.Regular:
                            Type = StateType.Start;
                            break;
                    }
                }
                else
                {
                    switch (Type)
                    {
                        case StateType.End:
                        case StateType.StartEnd:
                            Type = StateType.End;
                            break;
                        case StateType.Regular:
                        case StateType.Start:
                            Type = StateType.Regular;
                            break;
                    }
                }
            }
        }

        #endregion

        #region Methods

        public override void Draw(Graphics graphics, int scrollOffsetX, int scrollOffsetY)
        {
            RectangleF newRectangle = Rectangle;
            newRectangle.X += scrollOffsetX;
            newRectangle.Y += scrollOffsetY;

            graphics.FillEllipse(Brushes.White, newRectangle);

            graphics.DrawEllipse((IsSelected ? Pens.Red : Pens.Black), newRectangle);

            if (IsEndState)
            {
                graphics.DrawEllipse((IsSelected ? Pens.Red : Pens.Black), 
                    new RectangleF(newRectangle.X + 2, newRectangle.Y + 2,
                    newRectangle.Width - 4, newRectangle.Height - 4));
            }

            SizeF textSize = graphics.MeasureString(_label, _controlFont);

            float textX = newRectangle.X + (newRectangle.Width / 2f) - (textSize.Width / 2f);
            float textY = newRectangle.Y + (newRectangle.Height / 2f) - (textSize.Height / 2f);

            graphics.DrawString(_label, _controlFont, 
                (IsSelected ? Brushes.Red : Brushes.Black), 
                new PointF(textX, textY));

            if (IsStartState)
            {
                float underlineY = newRectangle.Y + (newRectangle.Height / 2f) + (textSize.Height / 2f);
                graphics.DrawLine((IsSelected ? Pens.Red : Pens.Black), 
                    textX, underlineY, textX + textSize.Width - 1, underlineY);
            }
        }

        public override string GenerateXml()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Statics.Space4}<state>");
            stringBuilder.AppendLine($"{Statics.Space8}<id>{_id}</id>");
            stringBuilder.AppendLine($"{Statics.Space8}<x>{Rectangle.X}</x>");
            stringBuilder.AppendLine($"{Statics.Space8}<y>{Rectangle.Y}</y>");
            stringBuilder.AppendLine($"{Statics.Space8}<label>{_label}</label>");
            stringBuilder.AppendLine($"{Statics.Space8}<type>{Type}</type>");
            stringBuilder.AppendLine($"{Statics.Space4}</state>");

            return stringBuilder.ToString();
        }

        public override PointF GetMaximum()
        {
            return Center + Rectangle.Size;
        }

        public override PointF GetMinimum()
        {
            return Center - Rectangle.Size;
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
