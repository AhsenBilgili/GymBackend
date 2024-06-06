using DenemeForeignKey.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DenemeForeignKey.Data
{
    public class DataContext: IdentityDbContext<IdentityUser>
    {
      
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }



        public DbSet<Facility> Facilities { get; set; }

        public DbSet<SpecialCourse>SpecialCourses { get; set; }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<SpecialCourseTrainer> SpecialCourseTrainers { get; set; }


        public DbSet<DaySchedule> DaySchedules { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<CoursePrice> CoursePrices { get; set; }

        public DbSet<UserCourseRegistration> UserCourseRegistrations { get; set; }
        public DbSet<HomePageCard> HomePageCards { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
