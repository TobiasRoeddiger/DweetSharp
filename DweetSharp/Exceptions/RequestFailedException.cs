using System;
namespace DweetSharp
{
    public class RequestFailedException : Exception
    {
        public string ErrorCode { get; private set; }

        public string ErrorMessage { get; private set; }

        public RequestFailedException(string errorCode, string errorMessage)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }
    }
}

