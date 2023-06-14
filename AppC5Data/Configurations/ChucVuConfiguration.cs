using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class ChucVuConfiguration:IEntityTypeConfiguration<ChucVu>
    {
        public void Configure(EntityTypeBuilder<ChucVu> builder)
        {
            builder.HasKey(c => c.IdChucVu);
            builder.Property(c => c.TenCV);
            builder.Property(c => c.TrangThai);
        }
    }
}
