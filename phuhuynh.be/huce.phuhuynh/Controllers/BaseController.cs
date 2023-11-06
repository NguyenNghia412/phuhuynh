using huce.phuhuynh.entities.Dto.BaseResponse;
using huce.phuhuynh.lib.ExceptionCustom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace huce.phuhuynh.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        protected IActionResult ResponseException(Exception allEx, int code = StatusCodes.Status500InternalServerError)
        {
            if (allEx.GetType() == typeof(CustomException))
            {
                var ex = (CustomException)allEx;

                _logger.LogError(ex.Message);
                return StatusCode(code, new ApiResponse { ErrorData = ex.ErrorData ?? ex.Data, ErrorCode = ex.ErrorCode ?? -1, Message = ex.Message });
            }
            else
            {
                _logger.LogError(allEx.Message);
                return StatusCode(code, new ApiResponse { ErrorData = allEx.Data, ErrorCode = -1, Message = allEx.Message });
            }
        }
    }
}
