namespace BanGiayTheThao.Models
{
    public class PhanLoaiSP
    {
        public Guid IdPhanLoaiSP { get; set; }
        public Guid? IdSize { get; set; }
        public Guid? IdSanPham { get; set; }
        public Guid? IDChatLieu { get; set; }
        public Guid? IDmau { get; set; }
        public Guid? IDNSX { get; set; }
        public int? Soluong { get; set; }
        public int? TrangThai { get; set; }

        public SanPham? SanPham { get; set; }
        public Size? Size { get; set; }
        public ChatLieu? CChatLieu { get; set; }
        public Mau? Mau { get; set; }
        public NSX? Nsx { get; set; }
        public virtual List<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual List<GioHangChiTiet> GioHangChiTiets { get; set; }
    }
}
