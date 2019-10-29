using System;

namespace Plooto.Core.Exceptions
{
    public class FailedToCreateTodoException : Exception
    {
        public FailedToCreateTodoException(string message)
            : base(message)
        {
            
        }
    }
}