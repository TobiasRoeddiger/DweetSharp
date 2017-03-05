using System;
namespace DweetSharp
{
    public class GETRequestFailedException : Exception
    {
        public string ErrorCode { get; private set; }

        public string ErrorMessage { get; private set; }

        public GETRequestFailedException(string errorCode, string errorMessage)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }
    }
}

