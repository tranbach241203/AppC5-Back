using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class NguoiDungConfiguration : IEntityTypeConfiguration<NguoiDung>
    {
        public void Configure(EntityTypeBuilder<NguoiDung> builder)
        {
            builder.HasKey(c => c.IdNguoiDung);
            builder.Property(c => c.Ho);
            builder.Property(c => c.Ten);
            builder.Property(c => c.TenDangNhap);
            builder.Property(c => c.MatKhau);
            builder.Property(c => c.SDT);
            builder.Property(c => c.DiaChi);
            builder.Property(c => c.Email);
            builder.Property(c => c.GioiTinh);
            builder.Property(c => c.TrangThai);
            builder.HasOne(c => c.ChucVus).WithMany(c => c.NguoiDung).HasForeignKey(c => c.IdChucVu);
           
        }
    }
}
