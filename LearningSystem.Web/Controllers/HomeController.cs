namespace LearningSystem.Web.Controllers
{
   using System.Diagnostics;
   using System.Threading.Tasks;
   using Models;
   using Microsoft.AspNetCore.Mvc;
   using Services;

   public class HomeController : Controller
   {

      private readonly ICourseService _courses;

      public HomeController(ICourseService courses)
      {
         this._courses = courses;
      }

        public async  Task<IActionResult> Index() =>View(await this._courses.Active());

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
               => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        
    }
}
