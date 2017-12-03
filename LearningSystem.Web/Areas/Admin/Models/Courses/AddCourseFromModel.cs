namespace LearningSystem.Web.Areas.Admin.Models.Courses
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using Microsoft.AspNetCore.Mvc.Rendering;
   using static Data.DataConstants;

   public class AddCourseFromModel : IValidatableObject
   {
      [Required]
      [MaxLength(CourseNameMaxLenght)]
      public string Name { get; set; }

      [Required]
      [MaxLength(CourseDescriptionMaxLength)]
      public string Description { get; set; }



      [DataType(DataType.Date)]
      public DateTime StartDate { get; set; }

      [DataType(DataType.Date)]
      public DateTime EndDate { get; set; }

      [Required]
      [Display(Name = "Trainer")]
      public string TrainerId { get; set; }

      public IEnumerable<SelectListItem> Trainers { get; set; }

      public IEnumerable<ValidationResult> Validate(ValidationContext validateContext)
      {
         if (this.StartDate < DateTime.UtcNow)
         {
            yield return new ValidationResult("Start date should be  in the future");
         }

         if (this.StartDate> this.EndDate)
         {
            yield return  new ValidationResult("Start date should be before end");
         }
      }

   }
}
