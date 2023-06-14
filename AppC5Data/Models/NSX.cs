namespace BanGiayTheThao.Models
{
    public class NSX
    {
        public Guid IdNSX { get; set; }
        public string? MaNSX { get; set; }
        public string? TenNSX { get; set; }
        public int? TrangThai { get; set; }

        public virtual List<PhanLoaiSP> PhanLoaiSps { get; set; }
    }
}
