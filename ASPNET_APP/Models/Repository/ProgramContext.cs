using System.Data.Entity;

namespace ASPNET_APP.Models.Repository
{
    public class ProgramContext : DbContext
    {
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<CompetitionAthlete> CompetitionAthletes { get; set; }
        public DbSet<CompetitionJudge> CompetitionJudges { get; set; }
        public DbSet<CompetitionCategory> CompetitionCategories { get; set; }
        public DbSet<AthleteCategory> AthleteCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ProgramContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}