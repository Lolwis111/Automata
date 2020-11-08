using System;

namespace AutomataGUI.Model.Exceptions
{
    [Serializable]
    public class InvalidAutomataException : Exception
    {
        public InvalidAutomataException() : base()
        {

        }

        public InvalidAutomataException(string message) : base(message)
        {

        }

        public InvalidAutomataException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
