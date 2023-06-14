namespace BanGiayTheThao.Models
{
    public class HoaDon
    {
        public Guid IdHoaDon { get; set; }
        public Guid? IDGiamGia { get; set; }
        public DateTime? NgayTao { get; set; }
        public Guid? IDNguoiDung { get; set; }
        public string? DiaChi { get; set; }
        public DateTime? NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public double? TongTien { get; set; }

        public int? TrangThai { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }
        public virtual GiamGia? GiamGia { get; set; }
        public  virtual List<HoaDonChiTiet> HoaDonChiTiet { get; set; }

    }
}
