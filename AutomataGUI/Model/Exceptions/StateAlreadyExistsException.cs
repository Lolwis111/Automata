using System;

namespace AutomataGUI.Model.Exceptions
{
    [Serializable]
    public class StateAlreadyExistsException : Exception
    {
        public StateAlreadyExistsException() : base()
        {

        }

        public StateAlreadyExistsException(string message) : base(message)
        {

        }

        public StateAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
