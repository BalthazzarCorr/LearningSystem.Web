namespace LearningSystem.Services.Admin.Implementation
{
   using System.Collections.Generic;
   using System.Linq;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Models;

   public class AdminUserService : IAdminUserService
   {
      private readonly LearningSystemDbContext db;
   
      public AdminUserService(LearningSystemDbContext db)
      {
         this.db = db;
      }

      public IEnumerable<AdminUserListingModel> All()
         => this.db.Users.ProjectTo<AdminUserListingModel>().ToList();
   }
}
