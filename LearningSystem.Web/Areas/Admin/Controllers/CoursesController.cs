namespace LearningSystem.Web.Areas.Admin.Controllers
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using Data.Models;
   using Infrastructure.Extensions;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Microsoft.AspNetCore.Mvc.Rendering;
   using Models.Courses;
   using Services.Admin;
   using Web.Controllers;

   public class CoursesController : BaseAdminController
   {
      private readonly UserManager<User> _userManager;

      private readonly IAdminCourseService _courses;

      public CoursesController(UserManager<User> userManager , IAdminCourseService courses)
      {
         this._userManager = userManager;
         this._courses = courses;
      }


      public async Task<IActionResult> Create() => View(new AddCourseFromModel
         {
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(30),
            Trainers = await GetTrainers()
         });
      

      [HttpPost]
      public async Task<IActionResult> Create(AddCourseFromModel model)
      {
         if (!ModelState.IsValid)
         {
            model.Trainers = await GetTrainers();
            return View(model);
         }

         await this._courses.CreateAsync(
            model.Name,
            model.Description,
            model.StartDate,
            model.EndDate,
            model.TrainerId
         );

         TempData.AddSuccessMessage($"Course {model.Name} created successfully");

         return RedirectToAction(nameof(HomeController.Index),"Home",new {area = string.Empty});
      }

      private async Task<IEnumerable<SelectListItem>> GetTrainers()
      {
         var trainers = await this._userManager.GetUsersInRoleAsync(WebConstants.TrainerRole);
         var trainerListItems = trainers.Select(t => new SelectListItem
         {
            Value = t.Id,
            Text = t.UserName
         }).ToList();

         

         return trainerListItems;
      }

   }
}
