using BanGiayTheThao.Models;

namespace AppC5API.ViewModels
{
    public class SaleView
    {
        public List<SanPham> sanPhams { get; set; }
        public List<KhuyenMai> khuyenMai { get; set; }
        public List<KmSanPham> KmSanPhams { get; set; }
    }
}
