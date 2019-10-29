using System;

namespace Plooto.Core.Exceptions
{
    public class FailedToUpdateTodoException : Exception
    {
        public FailedToUpdateTodoException(string message)
            : base(message)
        {

        }
    }
}