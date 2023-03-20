using HueFes.Models;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;

namespace HueFes.ViewModels
{
    public class SoatVeHistory
    {
        public ICollection<CheckinVM> Checkins { get; set; }

        public SoatVeHistory(List<CheckinVM> checkins)
        {
            this.Checkins = checkins;
        }
        public SoatVeHistory(DateTime? theoNgay, string? theoLoai, int? chuongTrinhId, List<CheckinVM> checkins)
        {
            if (theoLoai.IsNullOrEmpty() && !chuongTrinhId.HasValue && theoNgay.HasValue)
            {
                this.Checkins = checkins.Where(x => x.NgaySoatVe == theoNgay?.ToShortDateString())
                    .ToList();
            }
            if (!theoNgay.HasValue && !chuongTrinhId.HasValue && !theoLoai.IsNullOrEmpty())
            {
                this.Checkins = checkins.Where(x => x.LoaiVe == theoLoai)
                    .ToList();
            }
            if (!theoNgay.HasValue & theoLoai.IsNullOrEmpty() && chuongTrinhId.HasValue)
            {
                this.Checkins = checkins.Where(x => x.ChuongTrinhId == chuongTrinhId)
                    .ToList();
            }
            if (theoLoai.IsNullOrEmpty() && chuongTrinhId.HasValue && theoNgay.HasValue)
            {
                this.Checkins = checkins.Where(x => x.NgaySoatVe == theoNgay?.ToShortDateString())
                    .Where(x => x.ChuongTrinhId == chuongTrinhId)
                    .ToList();
            }
            if (!chuongTrinhId.HasValue && !theoLoai.IsNullOrEmpty() && theoNgay.HasValue)
            {
                this.Checkins = checkins.Where(x => x.NgaySoatVe == theoNgay?.ToShortDateString())
                    .Where(x => x.LoaiVe == theoLoai)
                    .ToList();
            }
            if (!theoNgay.HasValue && !theoLoai.IsNullOrEmpty() && chuongTrinhId.HasValue)
            {
                this.Checkins = checkins.Where(x => x.LoaiVe == theoLoai)
                    .Where(x => x.ChuongTrinhId == chuongTrinhId)
                    .ToList();
            }
            if (!theoLoai.IsNullOrEmpty() && theoNgay.HasValue && chuongTrinhId.HasValue)
            {
                this.Checkins = checkins.Where(x => x.NgaySoatVe == theoNgay?.ToShortDateString())
                    .Where(x => x.LoaiVe == theoLoai)
                    .Where(x => x.ChuongTrinhId == chuongTrinhId)
                    .ToList();
            }
            if (!theoNgay.HasValue && theoLoai.IsNullOrEmpty() && !chuongTrinhId.HasValue)
            {
                this.Checkins = checkins;
            }

        }
    }


}
