using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Invoke
{

    public class DefaultExceptionResponse
    {

        public DefaultExceptionResponse() { }
        
        public DefaultExceptionResponse(ServiceException ex)
        {
            this.StatusCode = (int) ex.StatusCode;
            this.Message = ex.Message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public int ResultCode { get; set; }

    }

}
