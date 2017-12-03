namespace LearningSystem.Web.Areas.Admin.Controllers
{
   using System.Linq;
   using System.Threading.Tasks;
   using Data.Models;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Microsoft.AspNetCore.Mvc.Rendering;
   using Models.Courses;

   public class CoursesController : BaseAdminController
   {
      private readonly UserManager<User> _userManager;

      public CoursesController(UserManager<User> userManager)
      {
         this._userManager = userManager;
      }


      public async Task<IActionResult> Create()
      {
         var trainers = await this._userManager.GetUsersInRoleAsync(WebConstants.TrainerRole);
         var trainerListItems = trainers.Select(t => new SelectListItem
         {
            Value = t.Id,
            Text = t.UserName
         }).ToList();

         return View(new AddCourseFromModel
         {
            Trainers = trainerListItems
         });
      }  

   }
}
