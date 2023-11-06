using huce.phuhuynh.entities.Dto.CdsConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huce.phuhuynh.domain.Interfaces
{
    public interface ICdsServices
    {
        public Task<SinhVienDto> GetSinhVienByMasvAsync(string masv);
        Task<List<ChiTietDiemDto>> GetChiTietDiemByMaSvAsync();
        Task<List<DiemTongKetDto>> GetDiemTongKetByMaSvAsync();
    }
}
