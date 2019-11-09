using System;

namespace Xxx.Domain.Exceptions
{
    public class XxxDomainException : Exception
    {
        public XxxDomainException()
        {
        }

        public XxxDomainException(string message) : base(message)
        {
        }

        public XxxDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
