namespace LearningSystem.Web.Areas.Admin.Models.Users
{
   using System.Collections.Generic;
   using Microsoft.AspNetCore.Mvc.Rendering;
   using Services.Admin.Models;

   public class AdminUsersViewListingModel
    {

       public IEnumerable<AdminUserListingModel> Users { get; set; }

       public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
