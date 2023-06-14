using BanGiayTheThao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BanGiayTheThao.Configurations
{
    public class ChatLieuConfiguration: IEntityTypeConfiguration<ChatLieu>
    {
        public void Configure(EntityTypeBuilder<ChatLieu> builder)
        {
            builder.HasKey(c => c.IdChatLieu);
            builder.Property(c => c.MaChatLieu);
            builder.Property(c => c.TenChatLieu);
        }
    }
}
