
using System.Collections.Generic;

namespace Automata
{
    public class State
    {
        public string Name
        {
            get { return _name; }
            set { if (!string.IsNullOrEmpty(value)) _name = value; }
        }
        private string _name;

        public bool IsEndState
        {
            get { return _end; }
            set { _end = value; }
        }
        private bool _end;

        public bool IsStartState
        {
            get { return _start; }
            set { _start = value; }
        }
        private bool _start;

        public Dictionary<char, string> Conditions
        {
            get { return _conditions; }
            set { _conditions = value; }
        }
        private Dictionary<char, string> _conditions = new Dictionary<char, string>();
    }
}
