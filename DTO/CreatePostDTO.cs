using GroupRareAPI.Models;

namespace GroupRareAPI.DTO
{
    public class CreatePostDTO

    {
        public string RareUserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? ImageUrl { get; set; }
        public string Content { get; set; }
        public bool Approved { get; set; }
      
    }
}
