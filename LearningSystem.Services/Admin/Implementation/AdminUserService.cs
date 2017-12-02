namespace LearningSystem.Services.Admin.Implementation
{
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Microsoft.EntityFrameworkCore;
   using Models;

   public class AdminUserService : IAdminUserService
   {
      private readonly LearningSystemDbContext db;
   
      public AdminUserService(LearningSystemDbContext db)
      {
         this.db = db;
      }

      public async Task<IEnumerable<AdminUserListingModel>> AllAsync()
         =>  await this.db.Users.ProjectTo<AdminUserListingModel>().ToListAsync();
   }
}
