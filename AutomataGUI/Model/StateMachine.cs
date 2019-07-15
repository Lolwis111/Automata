using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AutomataGUI.Model
{
    public sealed class StateMachine
    {
        /// <summary>
        /// The name of this state machine.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This class is used to order the drawables in a way, 
        /// that states will draw after the transations
        /// to avoid graphical artifacts
        /// </summary>
        private class ZLevelComparator : Comparer<Drawable>
        {
            public override int Compare(Drawable x, Drawable y)
            {
                if (x is State)
                {
                    if (y is State) return 0;
                    return 1;
                }

                if (x is Transition)
                {
                    if (x is State) return -1;
                    return 0;
                }

                return 0;
            }
        }

        public StateMachine()
        {
            _drawables.Clear();
        }

        public void Reorder()
        {
            Drawables.Sort(new ZLevelComparator());
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
            AddState(id, posX, posY, state.Label, state.Type);
        }

        public void AddState(int id, int posX, int posY, string label, StateType stateType)
        {
            switch (stateType)
            {
                case StateType.Regular:
                    AddState(id, posX, posY, label, false, false);
                    break;
                case StateType.End:
                    AddState(id, posX, posY, label, false, true);
                    break;
                case StateType.Start:
                    AddState(id, posX, posY, label, true, false);
                    break;
                case StateType.StartEnd:
                    AddState(id, posX, posY, label, true, true);
                    break;
            }
        }

        /// <summary>
        /// Adds a new state to the automaton at the specified position
        /// and with the specified label and properties.
        /// States that already exist can't be added.
        /// </summary>
        /// <param name="id">ID of the state</param>
        /// <param name="posX">X coordinate of state (drawing)</param>
        /// <param name="posY">Y coordinate of state (drawing)</param>
        /// <param name="label">The label of the state</param>
        /// <param name="isStartState">Is this a start state?</param>
        /// <param name="isEndState">Is this an end state?</param>
        /// <exception cref="StateAlreadyExistsException"></exception>
        public void AddState(int id, int posX, int posY, string label, bool isStartState, bool isEndState)
        {
            // check if a state with given id already exists
            if (!_drawables.Exists(x => ((x is State s) && (s.Id == id))))
            {
                State state = new State
                {
                    Id = id,
                    IsSelected = false,
                    Label = label,
                    Rectangle = new RectangleF(posX, posY, 64, 64),
                    Z = id
                };

                if (isStartState)
                {
                    if (isEndState)
                    {
                        state.Type = StateType.StartEnd;
                    }
                    else
                    {
                        state.Type = StateType.Start;
                    }
                }
                else
                {
                    if (isEndState)
                    {
                        state.Type = StateType.End;
                    }
                    else
                    {
                        state.Type = StateType.Regular;
                    }
                }

                _drawables.Add(state);

                _drawables.Sort((x, y) => (y.Z - x.Z));
            }
            else
            {
                throw new StateAlreadyExistsException($"A state with the id {id} already exists!");
            }
        }

        /// <summary>
        /// Finds the state with the given ID.
        /// </summary>
        /// <param name="id">The id to search</param>
        /// <returns>The state with the given ID. If no such state exists, null is returned.</returns>
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

        /// <summary>
        /// Returns a list of all transitions a state is connected to.
        /// </summary>
        /// <param name="state">The state to query.</param>
        /// <returns>The list of transitions.</returns>
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
