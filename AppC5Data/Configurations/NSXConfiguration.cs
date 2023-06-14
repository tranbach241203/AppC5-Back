using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class NSXConfiguration : IEntityTypeConfiguration<NSX>
    {
        public void Configure(EntityTypeBuilder<NSX> builder)
        {
            builder.HasKey(c => c.IdNSX);
            builder.Property(c => c.MaNSX);
            builder.Property(c => c.TenNSX);
            builder.Property(c => c.TrangThai);
        }
    }
}
