using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class MauConfiguration : IEntityTypeConfiguration<Mau>
    {
        public void Configure(EntityTypeBuilder<Mau> builder)
        {
            builder.HasKey(c => c.IdMau);
            builder.Property(c => c.MaMau);
            builder.Property(c => c.TenMau);
        }
    }
}
