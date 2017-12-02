namespace LearningSystem.Services.Admin
{
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using Models;

   public interface IAdminUserService
   {
    Task<IEnumerable<AdminUserListingModel>> AllAsync();
   }
}
