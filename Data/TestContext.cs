using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Test.Models;
using Test.Data.Configurations;
namespace Test.Data
{
    public class TestContext : DbContext
    {
        private IConfigurationRoot configuration;
        public TestContext() : base()
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Class> Classs { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Lession> Lessions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json")
             .Build();
            string connectionString = configuration.GetConnectionString("Connectionstring");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new LessionConfiguration());
            modelBuilder.ApplyConfiguration(new CampaignConfiguration());
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
