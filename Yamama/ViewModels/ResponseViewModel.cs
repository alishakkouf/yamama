using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Yamama.ViewModels
{
    public class ResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object ResponseData { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ResponseViewModel(bool status, HttpStatusCode StatusCode, string message, object data)
        {
            IsSuccess = status;
            this.StatusCode = StatusCode;
            Message = message;
            ResponseData = data;
        }
    }
}
