namespace RMS.ViewModel
{
    public class CandidateViewModel
    {
        // public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Department { get; set; }
        public FileStream Resume { get; set; }
    }
}
