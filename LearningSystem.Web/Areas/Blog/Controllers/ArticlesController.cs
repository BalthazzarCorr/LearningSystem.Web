namespace LearningSystem.Web.Areas.Blog.Controllers
{
   using System.Threading.Tasks;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Mvc;
   using Models;
   using static WebConstants;

   [Area(BlogArea)]
   [Authorize(Roles = BlogAuthorRole)]
   public class ArticlesController : Controller
   {
      public IActionResult Create() => View();

      [HttpPost]
      public async  Task<IActionResult> Create(PublishArticleFormModel model)
      {
         if (!ModelState.IsValid)
         {
            return View(model);
         }

         return null;
      }

   }
}