using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class SanPhamConfiguration : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.HasKey(c => c.IdSanPham);
            builder.Property(c => c.MaSanPham);
            builder.Property(c => c.TenSanPham);
            builder.Property(c => c.MoTa);
            builder.Property(c => c.TrangThai);
            builder.Property(c => c.GiaNhap);
            builder.Property(c => c.GiaBan);
            builder.Property(c => c.AnhDaidien);
            builder.Property(c => c.ChieuCaoDeGiay);
            
        }
    }
}
