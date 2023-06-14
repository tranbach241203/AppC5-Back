using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class GioHangChiTietConfiguration : IEntityTypeConfiguration<GioHangChiTiet>
    {
        public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
        {
            builder.HasKey(c => c.IdGioHangCT);
            builder.Property(c => c.SoLuong);
            builder.Property(c => c.TrangThai);
            
            builder.HasOne(c => c.GioHang).WithMany(c => c.GioHangChiTiets).HasForeignKey(c => c.IdGioHang);
            builder.HasOne(c => c.PhanLoaiSp).WithMany(c => c.GioHangChiTiets).HasForeignKey(c => c.IdPhanLoaiSP);
        }
    }
}
