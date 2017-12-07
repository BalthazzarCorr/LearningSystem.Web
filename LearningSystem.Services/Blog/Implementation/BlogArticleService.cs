namespace LearningSystem.Services.Blog.Implementation
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Threading.Tasks;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Data.Models;
   using Microsoft.EntityFrameworkCore;
   using Models;
   using static ServiceConstants;

   public class BlogArticleService : IBlogArticleService
   {

      private readonly LearningSystemDbContext _db;
     
      public BlogArticleService(LearningSystemDbContext db)
      {
         this._db = db;
        
      }


      public  async Task<ArticleDetailsModel> ArticleDetails(int id)
         => await this._db.Articles.Where(a => a.Id == id).ProjectTo<ArticleDetailsModel>().FirstOrDefaultAsync();
      

      public async Task<int> TotalAsyncArticles() => await this._db.Articles.CountAsync();

      public async Task CreateAsync(string title, string content, string authorId)
      {
         var article = new Article
         {
            Content = content,
            Title = title,
            AuthorId = authorId,
            PublishDate = DateTime.UtcNow,
         };

         this._db.Add(article);

         await this._db.SaveChangesAsync();
      }




      public async Task<IEnumerable<ArticleListingModel>> AllAsync(int page = 1) => await this._db
         .Articles
         .OrderByDescending(a => a.PublishDate)
         .Skip((page - 1) * BlogArticlesPageSize)
         .Take(BlogArticlesPageSize)
         .ProjectTo<ArticleListingModel>()
         .ToListAsync();


   }
}