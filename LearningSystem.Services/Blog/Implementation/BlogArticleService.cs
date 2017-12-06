namespace LearningSystem.Services.Blog.Implementation
{
   using System;
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using AutoMapper.QueryableExtensions;
   using Data;
   using Data.Models;
   using Microsoft.EntityFrameworkCore;
   using Models;

   public class BlogArticleService : IBlogArticleService
   {

      private readonly LearningSystemDbContext _db;
      private readonly IBlogArticleService _articles;

      public BlogArticleService(LearningSystemDbContext db , IBlogArticleService articles)
      {
         this._db = db;

         this._articles = articles; 
      }


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

      public async Task<IEnumerable<ArticleListingModel>> AllAsync()
                   =>  await this._db.Articles.ProjectTo<ArticleListingModel>().ToListAsync();


      
   }
}