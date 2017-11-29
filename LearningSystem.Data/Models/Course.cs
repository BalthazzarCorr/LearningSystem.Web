namespace LearningSystem.Data.Models
{
   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using Web.Models;
   using static DataConstants;

   public class Course
   {
      public int Id { get; set; }

      [Required]
      [MaxLength(CourseNameMaxLenght)]
      public string Name { get; set; }

      [Required]
      [MaxLength(CourseDescriptionMaxLength)]
      public string Description { get; set; }

      public string TrainerId { get; set; }

      public DateTime StartDate { get; set; }

      public DateTime EndDate { get; set; }

      public User Trainer { get; set; }

      public List<StudentCourse> Studnets { get; set; } = new List<StudentCourse>();
   }
}
