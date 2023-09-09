namespace GroupRareAPI.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string ImageUrl { get; set; }
        public List<Post> Posts { get; set; }
    }
}
