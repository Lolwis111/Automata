using System;
using System.Drawing;

namespace AutomataGUI.Model
{
    public abstract class Drawable : IDisposable
    {
        #region Fields

        public int Z
        {
            get { return _z; }
            set { _z = value; }
        }
        protected int _z;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        protected int _id;

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }
        protected string _label;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }
        protected bool _isSelected = false;

        protected readonly Font _controlFont = new Font("Arial", 8);

        #endregion

        #region Methods

        public abstract void Draw(Graphics graphics, int scrollOffsetX, int scrollOffsetY);

        public abstract string GenerateXml();

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _controlFont.Dispose();
                }

                // free unmanaged

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public RectangleF Rectangle
        {
            get
            {
                return _rectangle;
            }
            set
            {
                _rectangle = value;
            }
        }
        protected RectangleF _rectangle;

        public PointF Center
        {
            get { return new PointF(_rectangle.X + (_rectangle.Width / 2), _rectangle.Y + (_rectangle.Height / 2)); }
        }

        public override bool Equals(object obj)
        {
            if (obj is Drawable drawable)
            {
                return _id == drawable._id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _id;
        }

        #endregion
    }
}
