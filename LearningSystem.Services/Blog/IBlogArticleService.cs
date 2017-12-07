namespace LearningSystem.Services.Blog
{
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using Models;

   public interface IBlogArticleService
   {
      Task CreateAsync(string title, string content, string authorId);

      Task<ArticleDetailsModel> ArticleDetails(int id);
         
      Task<int> TotalAsyncArticles();

      Task<IEnumerable<ArticleListingModel>> AllAsync(int page = 1);
   }
}
