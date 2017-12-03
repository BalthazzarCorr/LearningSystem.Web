namespace LearningSystem.Web.Areas.Admin.Models.Courses
{
   using System.Collections.Generic;
   using Microsoft.AspNetCore.Mvc.Rendering;

   public class AddCourseFromModel
    {
       public IEnumerable<SelectListItem>Trainers { get; set; }
    }
}
