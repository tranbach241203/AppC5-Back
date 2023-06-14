namespace BanGiayTheThao.Models
{
    public class SanPham
    {
        public Guid IdSanPham { get; set; }
        public string? MaSanPham { get; set; }
        public string? TenSanPham { get; set; }
       
        public double? GiaBan { get; set; }
        public double? GiaNhap { get; set; }
        public double? ChieuCaoDeGiay { get; set; }
        public string? MoTa { get; set; }
        public string? AnhDaidien { get; set; }
        public int? TrangThai { get; set; }

        

      
        public virtual List<KmSanPham> KmSanPhams { get; set; }
        public List<Anh> Anhs { get; set; }
        public List<PhanLoaiSP> PhanLoaiSps { get; set; }


    }
}
