namespace LearningSystem.Services.Admin
{
   using System.Collections.Generic;
   using Models;

   public interface IAdminUserService
   {
      IEnumerable<AdminUserListingModel> All();
   }
}
