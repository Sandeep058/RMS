using Microsoft.EntityFrameworkCore;
using RMS.Models;

namespace RMS.Data
{
    public class CandidateDbContext : DbContext
    {
        public CandidateDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Candidate> Candidates { get; set; }
    }
}
