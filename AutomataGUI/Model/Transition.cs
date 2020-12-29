using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AutomataGUI.Model
{
    public sealed class Transition : Drawable
    {
        #region Fields

        public bool IsLoop
        {
            get { return StartPoint == EndPoint; }
        }

        public State StartPoint { get; set; }

        public State EndPoint { get; set; }

        private PointF control1, control2;

        public char[] TransitionCharacter
        {
            get
            {
                List<char> chars = new List<char>();
                foreach (string label in _label.Split(','))
                {
                    chars.Add(label[0]);
                }

                return chars.ToArray();
            }
        }

        #endregion

        #region Methods

        public override void Draw(Graphics graphics, int scrollOffsetX, int scrollOffsetY)
        {
            PointF centerStart = StartPoint.Center;
            centerStart.X += scrollOffsetX;
            centerStart.Y += scrollOffsetY;

            PointF centerEnd = EndPoint.Center;
            centerEnd.X += scrollOffsetX;
            centerEnd.Y += scrollOffsetY;
            
            if (IsLoop)
            {
                control1 = new PointF(centerStart.X - 100, centerStart.Y - 15);
                control2 = new PointF(centerStart.X - 15, centerStart.Y - 100);
            }
            else
            {
                float x = (centerStart.X + centerEnd.X) / 2;
                float y = (centerStart.Y + centerEnd.Y) / 2;

                float dx = Math.Abs(x) * Math.Sign(x);
                float dy = Math.Abs(y) * Math.Sign(y);

                int sign = StartPoint.Id > EndPoint.Id ? -1 : 1;
                float offset = sign * 100;

                control1 = (dx > dy) ? new PointF(dx, dy + offset) : new PointF(dx + offset, dy);

                control2 = control1;
            }

            graphics.DrawBezier(IsSelected ? Pens.Red : Pens.Black, centerStart, control1, control2, centerEnd);

            if (Statics.Debug)
            {
                graphics.DrawLine(Pens.Purple, control1, centerEnd);
                graphics.DrawLine(Pens.Blue, control2, centerStart);
                graphics.DrawLine(Pens.Green, control1, control2);

                graphics.FillEllipse(Brushes.Tomato, new RectangleF(CalculateArrowPosition(centerEnd, control2), new SizeF(6, 6)));
            }

            PointF p = CalculateArrowPosition(centerEnd, control2);
            graphics.FillRectangle(Brushes.Black, new RectangleF(p.X - 5, p.Y - 5, 10, 10));

            if (string.IsNullOrWhiteSpace(_label)) return;

            SizeF textSize = graphics.MeasureString(_label, _controlFont);

            PointF textLocation = CalculateMiddle(control1, control2);

            Rectangle = new RectangleF(textLocation, textSize);

            graphics.DrawString(_label, _controlFont, IsSelected ? Brushes.Red : Brushes.Black, textLocation);
        }

        public override string GenerateXml()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Statics.Space4}<transition>");
            stringBuilder.AppendLine($"{Statics.Space8}<id>{_id}</id>");
            stringBuilder.AppendLine($"{Statics.Space8}<label>{_label}</label>");
            stringBuilder.AppendLine($"{Statics.Space8}<from>{StartPoint.Id}</from>");
            stringBuilder.AppendLine($"{Statics.Space8}<to>{EndPoint.Id}</to>");
            stringBuilder.AppendLine($"{Statics.Space4}</transition>");

            return stringBuilder.ToString();
        }

        private static PointF CalculateMiddle(PointF p1, PointF p2)
        {
            return new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }

        private PointF CalculateNormVector(PointF point, PointF control2)
        {
            float x2 = point.X;
            float y2 = point.Y;

            float vx = x2 - control2.X;
            float vy = y2 - control2.Y;

            float abs = (float)Math.Sqrt((vx * vx) + (vy * vy));

            if (abs == 0.0f)
            {
                // dividing by zero is bad but visually 
                // its okay to adjust it a tiny little bit
                abs = 0.000001f;
            }

            float nx = vx / abs;
            float ny = vy / abs;

            return new PointF(nx, ny);
        }

        private PointF CalculateArrowPosition(PointF point, PointF control2)
        {
            PointF norm = CalculateNormVector(point, control2);

            return new PointF(point.X - (norm.X * ((EndPoint.Rectangle.Width + 4) / 2)) - 1,
                point.Y - (norm.Y * ((EndPoint.Rectangle.Height + 4) / 2)) - 1);
        }

        public override PointF GetMaximum()
        {
            float x1 = Math.Max(StartPoint.Center.X, EndPoint.Center.X);
            float y1 = Math.Max(StartPoint.Center.Y, EndPoint.Center.Y);

            float x2 = Math.Max(control1.X, control2.X);
            float y2 = Math.Max(control1.Y, control2.Y);

            return new PointF(Math.Max(x1, x2), Math.Max(y1,y2));
        }

        public override PointF GetMinimum()
        {
            float x1 = Math.Min(StartPoint.Center.X, EndPoint.Center.X);
            float y1 = Math.Min(StartPoint.Center.Y, EndPoint.Center.Y);

            float x2 = Math.Min(control1.X, control2.X);
            float y2 = Math.Min(control1.Y, control2.Y);

            return new PointF(Math.Min(x1, x2), Math.Min(y1, y2));
        }

        #endregion
    }
}