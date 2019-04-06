﻿using System;

namespace AutomataGUI.Model
{
    public class TransitionAlreadyExistsException : Exception
    {
        public TransitionAlreadyExistsException() : base()
        {

        }

        public TransitionAlreadyExistsException(string message) : base(message)
        {

        }

        public TransitionAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
