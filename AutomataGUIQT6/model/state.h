#pragma once

#include "statetype.h"
#include "drawable.h"

class State : public Drawable
{
private:
    StateType type;

public:
    State();
    ~State();

    bool getIsEndState()
    {
        return this->type == StateType_End || this->type == StateType_StartEnd;
    }

    bool getIsStartState()
    {
        return this->type == StateType_Start || this->type == StateType_StartEnd;
    }
    
    void setIsEndState(bool value);
    void setIsStartState(bool value);

    void Draw() override;
};