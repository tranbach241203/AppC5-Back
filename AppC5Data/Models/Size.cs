namespace BanGiayTheThao.Models
{
    public class Size
    {
        public Guid IdSize { get; set; }
        public int? SoSize { get; set; }
        public int? TrangThai { get; set; }

        public virtual List<PhanLoaiSP> PPhanLoaiSps { get; set; }
    }
}
