namespace GroupRareAPI.Models
{
    public class UserTypeChangeRequest
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public int AdminOneId { get; set; }
        public RareUser AdminOne { get; set; }
        public int AdminTwoId { get; set;}
        public RareUser AdminTwo { get; set; }
        public int ModifiedUserId { get; set;}
        public RareUser ModifiedUser { get; set; }
    }
}
