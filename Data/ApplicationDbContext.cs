using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using API.Models;
using API.Data.Configurations;
namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        private IConfigurationRoot configuration;
        public ApplicationDbContext() : base()
        {

        }
        public DbSet<Course> Course { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ClassUser> ClassUser { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json")
             .Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new CampaignConfiguration());
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ClassUserConfiguration());
            modelBuilder.ApplyConfiguration(new QuizConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        }
    }
}
