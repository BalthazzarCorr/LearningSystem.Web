﻿namespace LearningSystem.Web.Controllers
{
   using System.Threading.Tasks;
   using Data.Models;
   using Infrastructure.Extensions;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Services;
   using Models;
   using Models.Courses;
   using Services.Models;

   public class CoursesController : Controller
   {
      private readonly ICourseService _courses;

      private readonly UserManager<User> _userManager;

      public CoursesController(ICourseService courses, UserManager<User> userManager)
      {
         this._courses = courses;
         this._userManager = userManager;
      }

      public  async Task<IActionResult> Details(int id)
      {
         var model = new CourseDetailsViewModel
         {
            Course = await this._courses.ByIdAsync<CourseDetailsServiceModel>(id)
         };

         if (model.Course == null)
         {
            return NotFound();
         }


         if (User.Identity.IsAuthenticated)
         {
            var userId = this._userManager.GetUserId(User);
            model.UserIsSignedInCourse = await this._courses.UserIsSignedInCourse(id, userId);
         }

         return View(model);
      }

      [Authorize]
      [HttpPost]
      public async Task<IActionResult> SignIn(int id)
      {
         var userId = this._userManager.GetUserId(User);

         var success = await this._courses.SignInUser(id, userId);

         if (!success)
         {
            BadRequest();
         }

         TempData.AddSuccessMessage("You have been added to this course ");
         return RedirectToAction(nameof(Details), new {id});
      }

      [Authorize]
      [HttpPost]
      public async Task<IActionResult> SignOut(int id)
      {
         var userId = this._userManager.GetUserId(User);

         var success = await this._courses.SignOutUser(id, userId);

         if (!success)
         {
            return BadRequest();
         }

         TempData.AddSuccessMessage("Sorry to see you go!");

         return RedirectToAction(nameof(Details), new {id});
      }

   }
}
