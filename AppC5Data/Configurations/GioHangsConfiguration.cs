using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppC5Data.Configurations
{
    internal class GioHangsConfiguration : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.HasKey(c => c.IdGioHang);
            builder.Property(c => c.MoTa);
            builder.HasOne(c => c.NguoiDung).WithMany(c => c.GioHangs).HasForeignKey(c => c.IdNguoiDung);
        }
    }
}
