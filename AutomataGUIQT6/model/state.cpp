#include "state.h"
#include "statetype.h"

State::State()
{

}

State::~State()
{
    
}

void State::setIsEndState(bool value)
{
    if(value)
    {
        switch (this->type)
        {
            case StateType_Regular:
            case StateType_End:
                this->type = StateType_End;
                break;
            
            case StateType_Start:
            case StateType_StartEnd:
                this->type = StateType_StartEnd;
                break;
        }
    }
    else
    {
        switch (this->type)
        {
            case StateType_Regular:
            case StateType_End:
                this->type = StateType_Regular;
                break;
            
            case StateType_Start:
            case StateType_StartEnd:
                this->type = StateType_Start;
                break;
        }
    }
}

void State::setIsStartState(bool value)
{
    if(value)
    {
        switch (this->type)
        {
            case StateType_StartEnd:
            case StateType_End:
                this->type = StateType_StartEnd;
                break;
            
            case StateType_Start:
            case StateType_Regular:
                this->type = StateType_Start;
                break;
        }
    }
    else
    {
        switch (this->type)
        {
            case StateType_StartEnd:
            case StateType_End:
                this->type = StateType_End;
                break;
            
            case StateType_Start:
            case StateType_Regular:
                this->type = StateType_Regular;
                break;
        }
    }
}

void State::Draw()
{

}