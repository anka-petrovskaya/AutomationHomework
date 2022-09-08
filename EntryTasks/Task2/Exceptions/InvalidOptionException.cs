using System;

namespace EntryTasks.Task2.Exceptions
{
    public class InvalidOptionException : Exception
    {
        public InvalidOptionException(string message) : base(message)
        {

        }
    }
}