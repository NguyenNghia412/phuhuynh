using huce.motcua.entities.Settings;
using huce.phuhuynh.domain.Interfaces;
using huce.phuhuynh.entities.Dto.CdsConnect;
using huce.phuhuynh.lib;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace huce.phuhuynh.domain.Implements
{
    public class CdsServices : ICdsServices
    {
        private readonly ILogger<CdsServices> _logger;
        private readonly IHttpContextAccessor _httpContext;
        private readonly CDSConfig _cdsConfig;

        public CdsServices(
            ILogger<CdsServices> logger,
            IHttpContextAccessor httpContext,
            IOptions<CDSConfig> cdsConfig
        )
        {
            _logger = logger;
            _httpContext = httpContext;
            _cdsConfig = cdsConfig.Value;
        }

        /// <summary>
        /// Lấy thông tin sinh viên
        /// </summary>
        /// <param name="masv"></param>
        /// <returns></returns>
        public async Task<SinhVienDto> GetSinhVienByMasvAsync(string masv)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_cdsConfig.Connection),
            };

            var api = $"api/sv/{masv}";

            _logger.LogInformation($"Gọi api lấy thông tin sinh viên: {api}");
            var result = await httpClient.GetAsync(api);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await result.Content.ReadAsStringAsync();
                var resFormatted = JsonSerializer.Deserialize<ResponseSinhVienDto>(response);

                if (resFormatted.Code == 0)
                {
                    return resFormatted.Data;
                }
            }

            return null;
        }

        /// <summary>
        /// Lấy chi tiết điểm sinh viên
        /// </summary>
        /// <param name="masv"></param>
        /// <returns></returns>
        public async Task<List<ChiTietDiemDto>> GetChiTietDiemByMaSvAsync()
        {
            var username = CommonUtils.GetCurrentUsername(_httpContext);

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_cdsConfig.Connection),
            };

            var api = $"api/sv/chitietdiem/{username}";

            _logger.LogInformation($"Gọi api lấy chi tiết điểm sinh viên: {api}");
            var result = await httpClient.GetAsync(api);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await result.Content.ReadAsStringAsync();
                var resFormatted = JsonSerializer.Deserialize<ResponseChiTietDiemDto>(response);

                if (resFormatted.Code == 0)
                {
                    return resFormatted.Data;
                }
            }

            return null;
        }

        public async Task<List<DiemTongKetDto>> GetDiemTongKetByMaSvAsync()
        {
            var username = CommonUtils.GetCurrentUsername(_httpContext);

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_cdsConfig.Connection),
            };

            var api = $"api/sv/tongkethocki/{username}";

            _logger.LogInformation($"Gọi api lấy chi tiết điểm sinh viên: {api}");
            var result = await httpClient.GetAsync(api);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await result.Content.ReadAsStringAsync();
                var resFormatted = JsonSerializer.Deserialize<ResponseDiemTongKetDto>(response);

                if (resFormatted.Code == 0)
                {
                    return resFormatted.Data;
                }
            }

            return null;
        }
    }
}
