using System;

namespace Plooto.Core.Exceptions
{
    public class FailedToGetAllTodosException : Exception
    {
        public FailedToGetAllTodosException(string message)
            : base(message)
        {

        }
    }
}