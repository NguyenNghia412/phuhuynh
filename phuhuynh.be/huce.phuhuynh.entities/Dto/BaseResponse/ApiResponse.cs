using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huce.phuhuynh.entities.Dto.BaseResponse
{
    public class ApiResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public object ErrorData { get; set; }
    }
}
