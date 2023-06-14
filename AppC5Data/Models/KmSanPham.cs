namespace BanGiayTheThao.Models
{
    public class KmSanPham
    {
        public Guid IDKMSP { get; set; }
        public Guid? idSanPham { get; set; }
        public Guid? idKhuyenMai { get; set; }

        public virtual SanPham? SanPham { get; set; }
        public virtual KhuyenMai? KhuyenMai { get; set; }
    }
}
