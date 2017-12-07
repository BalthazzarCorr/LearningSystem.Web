namespace LearningSystem.Web.Areas.Blog.Models
{
   using System;
   using System.Collections.Generic;
   using Services;
   using Services.Blog.Models;

   public class ArticleListingViewModel
   {
      public IEnumerable<ArticleListingModel> Articles { get; set; }

      public int TotalArticles { get; set; }

      public int TotalPages => (int)Math.Ceiling((double) (this.TotalArticles / ServiceConstants.BlogArticlesPageSize));

      public int CurrentPage { get; set; }

      public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

      public int NextPage => this.CurrentPage == this.TotalPages ? TotalPages : this.CurrentPage + 1;
   }
}
