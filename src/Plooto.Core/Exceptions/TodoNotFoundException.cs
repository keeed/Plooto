using System;

namespace Plooto.Core.Exceptions
{
    public class TodoNotFoundException : Exception
    {
        public TodoNotFoundException(string id)
            : base(id)
        {

        }
    }
}