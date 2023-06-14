namespace BanGiayTheThao.Models
{
    public class Mau
    {
        public Guid IdMau { get; set; }
        public string? MaMau { get; set; }
        public string? TenMau { get; set; }

        public virtual List<PhanLoaiSP> PhanLoaiSps { get; set; }
    }
}
