using System;

namespace VerganeSteden.Exceptions
{
    public class OngeldigeZetException : Exception
    {
        public OngeldigeZetException()
        {
        }

        public OngeldigeZetException(string message)
            : base(message)
        {
        }

        public OngeldigeZetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}