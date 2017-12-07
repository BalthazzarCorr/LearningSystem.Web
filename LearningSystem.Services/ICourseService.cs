namespace LearningSystem.Services
{
   using System.Collections.Generic;
   using System.Threading.Tasks;

   public interface ICourseService
   {
      Task<IEnumerable<ICourseService>> Active();
   }
}
