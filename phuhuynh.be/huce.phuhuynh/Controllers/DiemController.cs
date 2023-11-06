using huce.phuhuynh.domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace huce.phuhuynh.Controllers
{
    [Route("api/diem")]
    [ApiController]
    [Authorize]
    public class DiemController : BaseController
    {
        private readonly ICdsServices _cdsServices;
        public DiemController(ICdsServices cdsServices, ILogger<BaseController> logger) : base(logger)
        {
            _cdsServices = cdsServices;
        }

        [HttpGet("chi-tiet")]
        public async Task<IActionResult> GetChiTietDiemSV()
        {
            try
            {
                var data = await _cdsServices.GetChiTietDiemByMaSvAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        [HttpGet("tong-ket")]
        public async Task<IActionResult> GetDiemTongKetSV()
        {
            try
            {
                var data = await _cdsServices.GetDiemTongKetByMaSvAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }
    }
       
}
