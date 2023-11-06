using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace huce.phuhuynh.lib.ExceptionCustom
{
    //[Serializable()]
    public class CustomException : Exception
    {
        public int? ErrorCode { get; set; }
        public object ErrorData { get; set; }

        public CustomException() { }

        public CustomException(string msg, int errCode = 200, object errData = null) : base(msg)
        {
            ErrorCode = errCode;
            ErrorData = errData;
        }
    }
}
