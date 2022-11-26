# AutomataGUI
Tool to design and simulate state machines

Visually design a finite state machine and test input strings against it.

# Features
* visual designer for finite state machines
* start states, end states, regular states
* transitions between states
* evaluation (test strings for acceptance)
* export as LaTeX
* export as PNG
* save/load as/from XML

# Known Bugs/Problems
* visual designer sometimes messes up rendering order
  * workaround: no known fix, try reloading
* bending angle of transitions not always nice
  * workaround: move around until no overlapping

# Things that would be cool
* label editor for transitions could be better (no intuitive what is valid or not)
* make drawing process faster (tearing and stuff going on)
* include minimization of state machine
* calculate regular expression from state machine(?)
* design automaton from regular expression(?)
