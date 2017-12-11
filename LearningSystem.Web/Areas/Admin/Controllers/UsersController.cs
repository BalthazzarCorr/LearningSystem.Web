namespace LearningSystem.Web.Areas.Admin.Controllers
{
   using System.Linq;
   using System.Threading.Tasks;
   using Data;
   using Data.Models;
   using Infrastructure.Extensions;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Microsoft.AspNetCore.Mvc.Rendering;
   using Microsoft.EntityFrameworkCore;
   using Models.Users;
   using Services.Admin;
   using Web.Models.AccountViewModels;


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

         var roles = await this._roleManager.Roles.Select(r => new SelectListItem
         {
            Text = r.Name,
            Value = r.Name
         }).ToListAsync();


         return View(new AdminUsersViewListingModel
         {
            Users = users,
            Roles = roles

         });
         
      }


      public JsonResult ListAll()
            => Json(_users.AllAsync().Result);

      [HttpPost]
      public JsonResult Add([FromBody] RegisterViewModel model)
      {
         var user = new User
         {
            UserName = model.Username,
            Name = model.Name,
            Email = model.Email,
            Birthdate = model.Birthdate
         };

         return Json(_userManager.CreateAsync(user, model.Password));
      }

      [HttpPost]
      public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
      {
         var roleExists = await this._roleManager.RoleExistsAsync(model.Role);
         var user = await this._userManager.FindByIdAsync(model.UserId);
         var userExists = user != null;
         if (!roleExists || !userExists)
         {
            ModelState.AddModelError(string.Empty, "Invalid identity details.");
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