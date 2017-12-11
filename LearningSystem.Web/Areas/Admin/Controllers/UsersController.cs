namespace LearningSystem.Web.Areas.Admin.Controllers
{
   using System.Threading.Tasks;
   using Data.Models;
   using Infrastructure.Extensions;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Models.Users;
   using Newtonsoft.Json;
   using Services.Admin;


   public class UsersController : BaseAdminController
   {
      private readonly IAdminUserService _users;
      private readonly RoleManager<IdentityRole> _roleManager;
      private readonly UserManager<User> _userManager;
 

      public UsersController(IAdminUserService users, RoleManager<IdentityRole> roleManager,
         UserManager<User> userManager)
      {
         this._users = users;
         this._roleManager = roleManager;
         this._userManager = userManager; 
      }





      public async Task<IActionResult> Index()
      {
         var users = await this._users.AllAsync();

         //var roles = await this._roleManager.Roles.Select(r => new SelectListItem
         //{
         //   Text = r.Name,
         //   Value = r.Name
         //}).ToListAsync();


         //return View(new AdminUsersViewListingModel
         //{
         //   Users = users,
         //   Roles = roles

         //});

         return View();
      }


      public JsonResult ListAll()
            =>Json(_users.AllAsync().Result);

         
      

      [HttpPost]
      public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
      {
         var roleExists = await this._roleManager.RoleExistsAsync(model.Role);
         var user = await this._userManager.FindByIdAsync(model.UserId)  ;
         var userExists = user != null;
         if (!roleExists || !userExists)
         {
            ModelState.AddModelError(string.Empty,"Invalid identity details.");
         }

         if (!ModelState.IsValid)
         {
            RedirectToAction(nameof(Index));
         }


         await this._userManager.AddToRoleAsync(user, model.Role);

         TempData.AddSuccessMessage($"Successfully added user {user.UserName} to {model.Role} role");
         return RedirectToAction(nameof(Index));
      }

   }
}