namespace RMS.Models
{
    public class Candidate
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Department { get; set; }
    }
}
