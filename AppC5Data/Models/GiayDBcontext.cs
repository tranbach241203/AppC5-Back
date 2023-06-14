
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BanGiayTheThao.Models
{
    public class GiayDBcontext : DbContext
    {
        public GiayDBcontext() { }

        public GiayDBcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Anh> Anhs { get; set; }
        public DbSet<ChatLieu> ChatLieus { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<GiamGia> GiamGias { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public DbSet<KmSanPham> KhSanPhams { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<Mau> Maus { get; set; }
        public DbSet<NSX> NSXs { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<PhanLoaiSP> PhanLoaiSps { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<Size> Sizess { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=LAPTOP-Q3TF2SAN\\SQLEXPRESS;Initial Catalog=AppC5;User ID=sa;Password=24122003");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}