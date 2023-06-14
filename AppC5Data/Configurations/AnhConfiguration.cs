using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class AnhConfiguration:IEntityTypeConfiguration<Anh>
    {
        public void Configure(EntityTypeBuilder<Anh> builder)
        {
            builder.HasKey(c => c.IdAnh);
            builder.Property(c => c.MaAnh);
            builder.Property(c => c.TenAnh);
            builder.Property(c => c.TrangThai);
            builder.Property(c => c.DuongDanAnh);
            builder.HasOne(c => c.SanPham).WithMany(c => c.Anhs).HasForeignKey(c => c.IdSanPham);
        }
    }
}
