using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AutomataGUI.Model
{
    public sealed class DataManager
    {
        public DataManager()
        {
            _drawables.Clear();
        }

        public List<Drawable> Drawables
        {
            get { return _drawables; }
            set { _drawables = value; }
        }
        private List<Drawable> _drawables = new List<Drawable>();

        public int StateCount
        {
            get
            {
                return _drawables.Count(x => (x is State));
            }
        }

        public int TransitionCount
        {
            get
            {
                return _drawables.Count(x => (x is Transition));
            }
        }

        public void AddTransition(State start, State end, int id, string label)
        {
            // check if this transition already exists
            if (!_drawables.Exists(x => ((x is Transition t) &&
                    (((t.StartPoint.Id == start.Id) && (t.EndPoint.Id == end.Id)) || (t.Id == id)))))
            {
                Transition transition = new Transition
                {
                    Id = id,
                    StartPoint = start,
                    EndPoint = end,
                    Label = label,
                    Z = _drawables.Count + 1
                };

                _drawables.Add(transition);

                _drawables.Sort((x, y) => (y.Z - x.Z));
            }
            else
            {
                throw new TransitionAlreadyExistsException($"A transition from {start.Id} to {end.Id} already exists!");
            }
        }

        public void AddTransition(State start, State end, int id)
        {
            AddTransition(start, end, id, Statics.Random.Next().ToString());
        }

        public void AddState(int id, int posX, int posY, State state)
        {
            AddState(id, posX, posY, state.Label, state.IsStartState, state.IsEndState);
        }

        public void AddState(int id, int posX, int posY, string label, bool isStartState, bool isEndState)
        {
            // check if a state with given id already exists
            if (!_drawables.Exists(x => ((x is State s) && (s.Id == id))))
            {
                State state = new State
                {
                    Id = id,
                    IsEndState = isEndState,
                    IsStartState = isStartState,
                    IsSelected = false,
                    Label = label,
                    Rectangle = new RectangleF(posX, posY, 64, 64),
                    Z = id
                };

                _drawables.Add(state);

                _drawables.Sort((x, y) => (y.Z - x.Z));
            }
            else
            {
                throw new StateAlreadyExistsException($"A state with the id {id} already exists!");
            }
        }

        public State FindStateById(int id)
        {
            foreach (State state in (from d in Drawables where (d is State) select d))
            {
                if (state.Id == id)
                {
                    return state;
                }
            }

            return null;
        }

        public List<Transition> FindTransitions(State state)
        {
            List<Transition> result = new List<Transition>();

            foreach (Transition transition in (from d in Drawables where (d is Transition) select d))
            {
                if (transition.StartPoint == state)
                {
                    result.Add(transition);
                }
                else if (transition.EndPoint == state)
                {
                    result.Add(transition);
                }
            }

            return result;
        }
    }
}
