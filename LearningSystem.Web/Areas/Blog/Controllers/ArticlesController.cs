﻿ namespace LearningSystem.Web.Areas.Blog.Controllers
{
   using System.Threading.Tasks;
   using Data.Models;
   using Infrastructure.Filters;
   using Infrastructure.Extensions;
   using Microsoft.AspNetCore.Authorization;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.AspNetCore.Mvc;
   using Models;
   using Services.Blog;
   using Services.Html;
   using static WebConstants;

   [Area(BlogArea)]
   [Authorize(Roles = BlogAuthorRole)]
   public class ArticlesController : Controller
   {
      public readonly IHtmlService _html;

      public readonly UserManager<User> _users;

      public readonly IBlogArticleService _articles;

      public ArticlesController(IHtmlService html,UserManager<User> users , IBlogArticleService articles)
      {
         this._html = html;
         this._articles = articles;
         this._users = users;
      }

      [ValidateModelState]
      public IActionResult Create() => View();

      [AllowAnonymous]
      public async Task<IActionResult> Index(int page = 1)
      {
         return   View(new ArticleListingViewModel()
         {
            Articles = await this._articles.AllAsync(page),
            TotalArticles = await this._articles.TotalAsyncArticles(),
            CurrentPage = page
         });
      }

      [HttpPost]
      [ValidateModelState]
      public async  Task<IActionResult> Create(PublishArticleFormModel model)
      {
         model.Content = this._html.Sanitize(model.Content);

         var userId = _users.GetUserId(User);

         await this._articles.CreateAsync(model.Title,model.Content,userId);

         return RedirectToAction(nameof(Index));
        
      }

      [AllowAnonymous]
      public async Task<IActionResult> Details(int id)
         => this.ViewOrNotFound(await this._articles.ArticleDetails(id));

   }
}