using System.Text.Json.Serialization;

namespace BanGiayTheThao.Models
{
    public class ChucVu
    {
        public Guid IdChucVu { get; set; }
        public string? TenCV { get; set; }
        public int? TrangThai { get; set; }
        [JsonIgnore]
        public virtual List<NguoiDung> NguoiDung { get; set; }

    }
}
