namespace BanGiayTheThao.Models
{
    public class KhuyenMai
    {
        public Guid IdKhuyenMai { get; set; }
        public string?MaKhuyenMai { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public double? SoTienGiam { get; set; }

        public virtual List<KmSanPham> KmSanPhams { get; set; }

    }
}
