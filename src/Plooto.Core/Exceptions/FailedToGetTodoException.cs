using System;

namespace Plooto.Core.Exceptions
{
    public class FailedToGetTodoException : Exception
    {
        public FailedToGetTodoException(string message)
            : base(message)
        {

        }
    }
}