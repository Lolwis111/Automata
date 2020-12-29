using System;

namespace AutomataGUI.Model.Exceptions
{
    [Serializable]
    public class StartStateAlreadyExistsException : Exception
    {
        public StartStateAlreadyExistsException() : base()
        {

        }

        public StartStateAlreadyExistsException(string message) : base(message)
        {

        }

        public StartStateAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
