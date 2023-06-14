namespace BanGiayTheThao.Models
{
    public class ChatLieu
    {
        public Guid IdChatLieu { get; set; }
        public string? MaChatLieu { get; set; }
        public string? TenChatLieu { get; set; }

        public virtual List<PhanLoaiSP> PPhanLoaiSps { get; set; }
    }
}
