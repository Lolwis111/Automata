using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AutomataGUI.Model.Exceptions;

namespace AutomataGUI.Model
{
    public sealed class StateMachine
    {
        /// <summary>
        /// The name of this state machine.
        /// </summary>
        public string Name { get; set; }

        public State StartState
        {
            get
            {
                return _startState;
            }
            set
            {
                if (HasStartState)
                {
                    throw new StartStateAlreadyExistsException();
                }
                else
                {
                    HasStartState = true;
                    _startState = value;
                }
            }
        }

        public bool HasStartState { get; set; } = false;

        private State _startState { get; set; } = null;

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
                    if (y is Transition) return 0;
                    return -1;
                }

                return 0;
            }
        }

        public StateMachine()
        {
            Drawables.Clear();
        }

        /// <summary>
        ///  Reoders the drawables so that states overlap transitions
        /// </summary>
        public void Reorder()
        {
            Drawables.Sort(new ZLevelComparator());
        }

        /// <summary>
        /// All the states and transitions
        /// </summary>
        public List<Drawable> Drawables { get; set; } = new List<Drawable>();

        public int StateCount
        {
            get
            {
                return Drawables.Count(x => (x is State));
            }
        }

        public int TransitionCount
        {
            get
            {
                return Drawables.Count(x => (x is Transition));
            }
        }

        /// <summary>
        /// Add a transition between the two given states.
        /// If a transition already exists a TransitionAlreadyExistsException is thrown.
        /// </summary>
        /// <param name="start">State to transition from</param>
        /// <param name="end">State to transition to</param>
        /// <param name="id">ID to give the transition</param>
        /// <param name="label">The label (determines how to transition)</param>
        /// <exception cref="TransitionAlreadyExistsException"></exception>
        public void AddTransition(State start, State end, int id, string label)
        {
            // check if this transition already exists
            if (!Drawables.Exists(x => ((x is Transition t) &&
                    (((t.StartPoint.Id == start.Id) && (t.EndPoint.Id == end.Id)) || (t.Id == id)))))
            {
                Transition transition = new Transition
                {
                    Id = id,
                    StartPoint = start,
                    EndPoint = end,
                    Label = label,
                    Z = Drawables.Count + 1
                };

                Drawables.Add(transition);

                Drawables.Sort((x, y) => (y.Z - x.Z));
            }
            else
            {
                throw new TransitionAlreadyExistsException($"A transition from {start.Id} to {end.Id} already exists!");
            }
        }

        /// <summary>
        /// Add a transition between the two given states.
        /// If a transition already exists a TransitionAlreadyExistsException is thrown.
        /// The label is assigned randomly.
        /// </summary>
        /// <param name="start">State to transition from</param>
        /// <param name="end">State to transition to</param>
        /// <param name="id">ID to give the transition</param>
        /// <exception cref="TransitionAlreadyExistsException"></exception>
        public void AddTransition(State start, State end, int id)
        {
            AddTransition(start, end, id, Statics.Random.Next().ToString());
        }

        /// <summary>
        /// Adds a new state to the automaton at the specified position
        /// and with the specified label and properties.
        /// States that already exist can't be added.
        /// </summary>
        /// <param name="id">ID of the state</param>
        /// <param name="posX">X coordinate of state (drawing)</param>
        /// <param name="posY">Y coordinate of state (drawing)</param>
        /// <param name="state">State which to copy label and type from</param>
        /// <exception cref="StateAlreadyExistsException"></exception>
        public void AddState(int id, int posX, int posY, State state)
        {
            AddState(id, posX, posY, state.Label, state.Type);
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
        /// <param name="stateType">Type of the state</param>
        /// <exception cref="StateAlreadyExistsException"></exception>
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
            if (!Drawables.Exists(x => ((x is State s) && (s.Id == id))))
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
                    if (HasStartState)
                    {
                        throw new StartStateAlreadyExistsException("This Automaton already contains a start state!");
                    }

                    if (isEndState)
                    {
                        state.Type = StateType.StartEnd;
                    }
                    else
                    {
                        state.Type = StateType.Start;
                    }

                    HasStartState = true;
                    _startState = state;
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

                Drawables.Add(state);

                Drawables.Sort((x, y) => (y.Z - x.Z));
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
                if (transition.StartPoint == state || transition.EndPoint == state)
                {
                    result.Add(transition);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a list of all transitions a state is connected to.
        /// </summary>
        /// <param name="state">The state to query.</param>
        /// <returns>The list of transitions outgoing from the state.</returns>
        public List<Transition> FindOutgoingTransitions(State state)
        {
            List<Transition> result = new List<Transition>();

            foreach (Transition transition in (from d in Drawables where (d is Transition) select d))
            {
                if (transition.StartPoint == state)
                {
                    result.Add(transition);
                }
            }

            return result;
        }

        public List<Transition> FindIngoingTransitions(State state)
        {
            List<Transition> result = new List<Transition>();

            foreach (Transition transition in (from d in Drawables where (d is Transition) select d))
            {
                if (transition.EndPoint == state)
                {
                    result.Add(transition);
                }
            }

            return result;
        }

        /// <summary>
        /// Tests if the given input string gets accepted by
        /// the language that the automaton represents.
        /// </summary>
        /// <param name="input">The string to test.</param>
        /// <returns>Boolean of wether or not it was accepted.</returns>
        public bool Evaluate(string input)
        {
            // check if start state is given
            if (!HasStartState)
                throw new InvalidAutomataException("The given automaton has no start state!");

            // if input is empty we check if the start state is an end state
            if (input.Length == 0)
                return _startState.IsEndState;


            // start 
            State state = _startState;

            // process each character
            foreach(char c in input)
            {
                // get all transitions from the current state
                List<Transition> transitions = FindOutgoingTransitions(state);

                bool foundNext = false;
                // and find a transition that matches the character
                foreach (Transition trans in transitions)
                {
                    if (trans.TransitionCharacter.Contains(c))
                    {
                        // if one is find we transition to the next state
                        state = trans.EndPoint;
                        foundNext = true;
                        break;
                    }
                }

                // if no next one is found the word is not accepted
                if (!foundNext)
                {
                    return false;
                }
            }

            // accept if we end on an end state
            return state.IsEndState;
        }
    }
}
