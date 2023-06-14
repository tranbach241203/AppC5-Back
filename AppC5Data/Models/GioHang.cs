namespace BanGiayTheThao.Models
{
    public class GioHang
    {
        public Guid IdGioHang { get; set; }
        public Guid IdNguoiDung { get; set; }
        public string? MoTa { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }
        public virtual List<GioHangChiTiet> GioHangChiTiets { get; set; }
    }
}
