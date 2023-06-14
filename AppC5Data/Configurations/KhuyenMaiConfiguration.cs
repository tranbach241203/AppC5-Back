using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class KhuyenMaiConfiguration : IEntityTypeConfiguration<KhuyenMai>
    {
        public void Configure(EntityTypeBuilder<KhuyenMai> builder)
        {
            builder.HasKey(c => c.IdKhuyenMai);
            builder.Property(c => c.MaKhuyenMai);
            builder.Property(c => c.NgayBatDau);
            builder.Property(c => c.NgayKetThuc);
            builder.Property(c => c.SoTienGiam);
        }
    }
}
