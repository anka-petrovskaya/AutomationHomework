using System;

namespace EntryTasks.Task2.Exceptions
{
    public class InvalidFormatException : Exception
    {
        public InvalidFormatException(string message) : base(message)
        {

        }
    }
}