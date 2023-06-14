using BanGiayTheThao.Models;

namespace AppC5API.ViewModel
{
    public class XemView
    {
        public SanPham sanPhams { get; set; }
        public IEnumerable<NSX> Nsxes { get; set; }
        public IEnumerable<ChatLieu> ChatLieus { get; set; }
        public IEnumerable<Mau> mau;
        public IEnumerable<PhanLoaiSP> PhanLoaiSps { get; set; }
        public IEnumerable<Size> Sizes { get; set; }
        public IEnumerable<Anh> Anhs { get; set; }
    }
}
