using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class PhanLoaiSPConfiguration : IEntityTypeConfiguration<PhanLoaiSP>
    {
        public void Configure(EntityTypeBuilder<PhanLoaiSP> builder)
        {
            builder.HasKey(c => c.IdPhanLoaiSP);
            builder.Property(c => c.Soluong);
            builder.Property(c => c.TrangThai);
          
            builder.HasOne(c => c.Size).WithMany(c => c.PPhanLoaiSps).HasForeignKey(c => c.IdSize);
            builder.HasOne(c => c.SanPham).WithMany(c => c.PhanLoaiSps).HasForeignKey(c => c.IdSanPham);
            builder.HasOne(c => c.CChatLieu).WithMany(c => c.PPhanLoaiSps).HasForeignKey(c => c.IDChatLieu);
            builder.HasOne(c => c.Mau).WithMany(c => c.PhanLoaiSps).HasForeignKey(c => c.IDmau);
            builder.HasOne(c => c.Nsx).WithMany(c => c.PhanLoaiSps).HasForeignKey(c => c.IDNSX);
        }
    }
}
