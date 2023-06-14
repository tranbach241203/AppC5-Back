using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class giamGiaConfiguration:IEntityTypeConfiguration<GiamGia>
    {
        public void Configure(EntityTypeBuilder<GiamGia> builder)
        {
            builder.HasKey(c => c.IdGiamGia);
            builder.Property(c => c.MaGiamGia);
            builder.Property(c => c.TenGiamGia);
            builder.Property(c => c.SoTienDaGiam);
        }
    }
}
