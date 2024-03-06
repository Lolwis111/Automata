# AutomataGUI
Tool to design and simulate state machines

Visually design a finite state machine and test input strings against it.

# Features
* visual designer for finite state machines
* start states, end states, regular states
* transitions between states
* evaluation (test strings for acceptance)
* export as LaTeX
  * tikz package is needed to compile the LaTeX
* export as PNG
* save/load as/from XML
* Works okay on Linux using Wine

# Known Bugs/Problems
* visual designer sometimes messes up rendering order
  * workaround: no known fix, try reloading
* bending angle of transitions not always nice
  * workaround: move around until no overlapping
* No check if the drawn automata is actually a DFA
  * A state can have to different outgoing transitions with the same letter

# Things that would be cool
* label editor for transitions could be better (no intuitive sign what is valid or not)
* make drawing process faster (tearing and stuff going on)
* include minimization of state machine
* calculate regular expression from state machine(?)
* design automaton from regular expression(?)
* given a word show the path it was processed on
