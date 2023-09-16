namespace GroupRareAPI.Models
{
    public class PostReaction
    {
        public int Id { get; set; }
        public Post Post { get; set; }
        public Reaction Reaction { get; set; }
        public RareUser RareUser{ get; set; }
    }
}
