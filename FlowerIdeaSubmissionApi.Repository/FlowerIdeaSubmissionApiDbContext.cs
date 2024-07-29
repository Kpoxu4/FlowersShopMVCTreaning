using FlowerIdeaSubmissionApi.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace FlowerIdeaSubmissionApi.Repository
{
    public class FlowerIdeaSubmissionApiDbContext : DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Database=FlowerIdeaSubmissionApi";

        public DbSet<Idea> Ideas { get; set; }

        public FlowerIdeaSubmissionApiDbContext() { }
        public FlowerIdeaSubmissionApiDbContext(DbContextOptions<FlowerIdeaSubmissionApiDbContext> contextOptions) : base(contextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(CONNECTION_STRING);
        }
    }
}
