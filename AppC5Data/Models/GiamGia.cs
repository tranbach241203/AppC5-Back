namespace BanGiayTheThao.Models
{
    public class GiamGia
    {
        public Guid IdGiamGia { get; set; }
        public string? MaGiamGia { get; set; }
        public double? SoTienDaGiam { get; set; }
        public string? TenGiamGia { get; set; }


        public virtual List<HoaDon> HoaDons { get; set; }
    }
}
