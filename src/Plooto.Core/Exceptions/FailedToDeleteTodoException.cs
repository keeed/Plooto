using System;

namespace Plooto.Core.Exceptions
{
    public class FailedToDeleteTodoException : Exception
    {
        public FailedToDeleteTodoException(string message)
            : base(message)
        {

        }
    }
}