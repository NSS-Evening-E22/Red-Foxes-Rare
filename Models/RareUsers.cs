namespace GroupRareAPI.Models
{
    public class RareUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Email { get; set; }
        public DateTime CreateOn { get; set; }
        public bool Active { get; set; }
        public bool IsStaff { get; set; }
        public string UID { get; set; }

        public List <Subscription> subscriptions { get; set; }

        public List <Comment> comments { get; set; } 
   
    }
}
