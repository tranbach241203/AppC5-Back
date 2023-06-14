namespace BanGiayTheThao.Models
{
    public class GioHangChiTiet
    {
        public Guid IdGioHangCT { get; set; }
        public Guid? IdGioHang { get; set; }
        public Guid? IdPhanLoaiSP { get; set; }
        public int? SoLuong { get; set; }
        public int? TrangThai { get; set; }

        public virtual GioHang? GioHang { get; set; }
        public virtual PhanLoaiSP PhanLoaiSp { get; set; }
    }
}
