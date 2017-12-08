namespace LearningSystem.Services.Implementation
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Microsoft.EntityFrameworkCore;
   using Models;

   public class CourseService : ICourseService
   {
      private readonly LearningSystemDbContext _db;

      public CourseService(LearningSystemDbContext db)
      {
         this._db = db;
      }

      public async Task<IEnumerable<CourseListingServiceModel>> Active()
         => await this._db.Courses.OrderByDescending(c => c.Id).Where(c => c.StartDate >= DateTime.UtcNow)
            .ProjectTo<CourseListingServiceModel>().ToListAsync();
   }
}
