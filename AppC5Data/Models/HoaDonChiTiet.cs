namespace BanGiayTheThao.Models
{
    public class HoaDonChiTiet
    {
        public Guid IdHoaDonChiTiet { get; set; }
        public Guid? IDhoaDon { get; set; }
        public Guid? IdPhanLoaiSP { get; set; }
        public int? SoLuong { get; set; }
        public double? GiaTien { get; set; }


        public virtual HoaDon? HoaDon { get; set; }
        public virtual PhanLoaiSP? PhanLoaiSp { get; set; }
    }
}
