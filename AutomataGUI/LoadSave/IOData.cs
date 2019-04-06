using AutomataGUI.Model;

namespace AutomataGUI.LoadSave
{
    public class IOData
    {
        public IOData(DataManager manager, int idx, int scrollX, int scrollY)
        {
            _manager = manager;
            _idx = idx;
            _scrollX = scrollX;
            _scrollY = scrollY;
        }

        public DataManager Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }
        private DataManager _manager;

        public int IdX
        {
            get { return _idx; }
            set { _idx = value; }
        }
        private int _idx;

        public int ScrollX
        {
            get { return _scrollX; }
            set { _scrollX = value; }
        }
        private int _scrollX;

        public int ScrollY
        {
            get { return _scrollY; }
            set { _scrollY = value; }
        }
        private int _scrollY;
    }
}
