using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(c => c.IdSize);
            builder.Property(c => c.SoSize);
            builder.Property(c => c.TrangThai);
        }
    }
}
