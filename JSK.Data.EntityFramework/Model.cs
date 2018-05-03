using JSK.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JSK.Data.EntityFramework
{
    public class Model : DbContext
    {
        private readonly string connectionString;

        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<TestQuestionAnswer> TestQuestionAnswers { get; set; }
        
        public Model(string connectionString) : base()
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}