using System;
using System.Collections.Generic;
using System.Text;

namespace SendTestMessageZNS.Data.ResponseModels
{
    public abstract class ResponseBase
    {
        public string Message { get; set; }
        public int Error { get; set; }
        public string Data { get; set; }
    }
}
