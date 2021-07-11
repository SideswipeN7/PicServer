using System;

namespace Pic.Shared.Exceptions
{
    public class AppException : Exception
    {
        public AppException(string message) : base(message) { }

        public AppException() : base()
        {
        }

        public AppException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}