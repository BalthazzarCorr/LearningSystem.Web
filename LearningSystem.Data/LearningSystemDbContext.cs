namespace LearningSystem.Data
{
   using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
   using Microsoft.EntityFrameworkCore;
   using Models;

   public class LearningSystemDbContext : IdentityDbContext<User>
   {
      public LearningSystemDbContext(DbContextOptions<LearningSystemDbContext> options)
          : base(options)
      {
      }

      public DbSet<Course> Courses { get; set; }
      public DbSet<Article> Articles { get; set; }
      

      protected override void OnModelCreating(ModelBuilder builder)
      {
         builder.Entity<StudentCourse>().HasKey(c => new {c.CourseId, c.StudentId});

         builder.Entity<StudentCourse>().HasOne(c => c.Student).WithMany(s => s.Courses).HasForeignKey(x=>x.StudentId);

         builder.Entity<StudentCourse>().HasOne(c => c.Course).WithMany(s => s.Studnets).HasForeignKey(c => c.CourseId);


         builder.Entity<Course>().HasOne(c => c.Trainer).WithMany(c => c.Trainings).HasForeignKey(c => c.TrainerId);

         builder.Entity<Article>().HasOne(c => c.Author).WithMany(c => c.Articles).HasForeignKey(c => c.AuthorId);

         base.OnModelCreating(builder);
        
      }
   }
}
