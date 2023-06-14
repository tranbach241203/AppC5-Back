using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class HoaDonChiTietConfiguration : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.HasKey(c => c.IdHoaDonChiTiet);
            builder.Property(c => c.SoLuong);
            builder.Property(c => c.GiaTien);

            builder.HasOne(c => c.HoaDon).WithMany(c => c.HoaDonChiTiet).HasForeignKey(c => c.IDhoaDon);
            builder.HasOne(c => c.PhanLoaiSp).WithMany(c => c.HoaDonChiTiets).HasForeignKey(c => c.IdPhanLoaiSP);
        }
    }
}
