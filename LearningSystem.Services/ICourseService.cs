namespace LearningSystem.Services
{
   using System.Collections.Generic;
   using System.Threading.Tasks;
   using Models;

   public interface ICourseService
   {
      Task<TModel> ByIdAsync<TModel>(int id) where TModel:class ;

      Task<bool> UserIsSignedInCourse(int courseId, string userId);

      Task<bool> SignInUser(int courseId,string userId);
     
      Task<IEnumerable<CourseListingServiceModel>> Active();
   }
}
