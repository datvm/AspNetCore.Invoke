using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace AspNetCore.Invoke
{

    public class ServiceException : Exception
    {

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
        public int ResultCode { get; set; } = 0;

        public ServiceException() { }

        public ServiceException(string message) : base(message) { }

        public ServiceException(string message, HttpStatusCode statusCode) : this(message)
        {
            this.StatusCode = statusCode;
        }

        public ServiceException(string message, HttpStatusCode statusCode, int resultCode) : this(message, statusCode)
        {
            this.StatusCode = statusCode;
            this.ResultCode = resultCode;
        }

        public ServiceException(string message, Exception innerException) : base(message, innerException) { }

        protected ServiceException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }

}
