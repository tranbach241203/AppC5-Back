namespace BanGiayTheThao.Models
{
    public class NguoiDung
    {
        public Guid IdNguoiDung { get; set; }
        public string? Ho { get; set; }
        public string? Ten { get; set; }
        public string? TenDangNhap { get; set; }
        public string? MatKhau { get; set; }
        public Guid? IdChucVu { get; set; }
        public int? GioiTinh { get; set; }
        public string? Email { get; set; }
        public string? SDT { get; set; }
        public string? DiaChi { get; set; }
        public int? TrangThai { get; set; }

       
        public virtual List<HoaDon> HoaDon { get; set; }
        public virtual List<GioHang> GioHangs { get; set; }
        public virtual ChucVu ChucVus { get; set; }

    }
}
