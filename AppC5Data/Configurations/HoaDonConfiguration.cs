using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.HasKey(c => c.IdHoaDon);
            builder.Property(c => c.NgayTao);
            builder.Property(c => c.DiaChi);
            builder.Property(c => c.TrangThai);
            builder.Property(c => c.TongTien);
            builder.Property(c => c.NgayDat);
            builder.Property(c => c.NgayGiao);
            builder.HasOne(c => c.GiamGia).WithMany(c => c.HoaDons).HasForeignKey(c => c.IDGiamGia);
            builder.HasOne(c => c.NguoiDung).WithMany(c => c.HoaDon).HasForeignKey(c => c.IDNguoiDung);
        }
    }
}
