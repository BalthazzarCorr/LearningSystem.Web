namespace LearningSystem.Web.Areas.Admin.Controllers
{
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Mvc;
   using Services.Admin;

   [Area("Admin")]
   [Authorize(Roles = WebConstants.AdministratorRole)]
   public class UsersController : Controller
   {
      private readonly IAdminUserService _users;


      public UsersController(IAdminUserService users)
      {
         this._users = users;
      }


      public IActionResult Index() => View(this._users.All());

   }
}