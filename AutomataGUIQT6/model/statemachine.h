#include "drawable.h"
#include <vector>

class StateMachine
{
private:

    std::vector<Drawable> drawables;

public:
    StateMachine();
    ~StateMachine();

};