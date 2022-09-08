using System;

namespace EntryTasks.Task2.Exceptions
{
    public class InvalidFlowersCountException : Exception
    {
        public InvalidFlowersCountException(string message) : base(message)
        {
        }
    }
}