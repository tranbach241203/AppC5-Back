using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class KMSanPhamConfiguration : IEntityTypeConfiguration<KmSanPham>
    {
        public void Configure(EntityTypeBuilder<KmSanPham> builder)
        {
            builder.HasKey(c => c.IDKMSP);
            builder.HasOne(c => c.SanPham).WithMany(c => c.KmSanPhams).HasForeignKey(c => c.idSanPham);
            builder.HasOne(c => c.KhuyenMai).WithMany(c => c.KmSanPhams).HasForeignKey(c => c.idKhuyenMai);
        }
    }
}
