namespace LearningSystem.Services.Admin.Implementation
{
   using System;
   using System.Threading.Tasks;
   using Data;
   using Data.Models;

   public class AdminCourseService : IAdminCourseService
   {
      private readonly LearningSystemDbContext _db;

      public AdminCourseService(LearningSystemDbContext db)
      {
         this._db = db;
      }

      public async Task Create(string name, string description, DateTime startDate, DateTime endDate, string trainerId)
      {
         var course =  new Course
         {
            Name = name,
            Description = description,
            StartDate = startDate,
            EndDate = endDate,
            TrainerId = trainerId
         };

         this._db.Add(course);

         await this._db.SaveChangesAsync();

      }
   }
}
