namespace LearningSystem.Services.Implementation
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Data.Models;
   using Microsoft.EntityFrameworkCore;
   using Models;

   public class CourseService : ICourseService
   {
      private readonly LearningSystemDbContext _db;

      public CourseService(LearningSystemDbContext db)
      {
         this._db = db;
      }

      public async Task<TModel> ByIdAsync<TModel>(int id) where TModel : class
         => await this._db
            .Courses
            .Where(c => c.Id == id)
            .ProjectTo<TModel>()
            .FirstOrDefaultAsync();

      public async Task<bool> UserIsSignedInCourse(int courseId, string userId)
         => await this._db.Courses
         .AnyAsync(c => c.Id == courseId && c.Studnets.Any(s => s.StudentId == userId));

      public async Task<bool> SignInUser(int courseId, string userId)
      {
         var courseInfo = await this._db.Courses.Select(c => new
         {c.StartDate,
            UserIdSignedIn = c.Studnets.Any(s => s.StudentId == userId)
         }).FirstOrDefaultAsync();

         if (courseInfo == null||courseInfo.StartDate < DateTime.UtcNow || courseInfo.UserIdSignedIn)
         {
            return false;
         }
         var studenCourse = new StudentCourse
         {
            CourseId = courseId,
            StudentId = userId
         };

         this._db.Add(studenCourse);

        await  this._db.SaveChangesAsync();

         return true;
      }

      public async Task<IEnumerable<CourseListingServiceModel>> Active()
         => await this._db.Courses
         .OrderByDescending(c => c.Id)
         .Where(c => c.StartDate >= DateTime.UtcNow)
         .ProjectTo<CourseListingServiceModel>()
         .ToListAsync();
   }
}
