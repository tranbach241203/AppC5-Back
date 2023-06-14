namespace BanGiayTheThao.Models
{
    public class Anh
    {
        public Guid IdAnh { get; set; }
        public Guid? IdSanPham { get; set; }
        public string? MaAnh { get; set; }
        public string? TenAnh { get; set; }
        public string? DuongDanAnh { get; set; }
        public int? TrangThai { get; set; }
        public SanPham? SanPham { get; set; }
    }
}
