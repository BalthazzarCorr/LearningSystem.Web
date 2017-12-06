namespace LearningSystem.Services.Blog
{
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using Models;

   public interface IBlogArticleService
   {
      Task CreateAsync(string title, string content, string authorId);

      Task<IEnumerable<ArticleListingModel>> AllAsync();
   }
}
