using JSK.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestQuestion>()
              .HasOne(p => p.Test)
              .WithMany(b => b.TestQuestions)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TestQuestionAnswer>()
             .HasOne(p => p.TestQuestion)
             .WithMany(b => b.TestQuestionAnswers)
             .OnDelete(DeleteBehavior.Cascade);

            

            base.OnModelCreating(modelBuilder);
        }
    }

    public class ModelContextFactory : IDesignTimeDbContextFactory<Model>
    {
        public Model CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");

            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<Model>();

            return new Model(connectionString);
        }
    }
}