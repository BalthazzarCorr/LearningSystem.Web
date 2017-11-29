namespace LearningSystem.Web.Models
{
   using System;
   using System.Collections.Generic;
   using Data.Models;
   using Microsoft.AspNetCore.Identity;



   public class User : IdentityUser
   {
      public string Name { get; set; }

      public DateTime Birthdate { get; set; }

      public List<Article> Articles { get; set; } = new List<Article>();

      public List<Course> Trainings { get; set; } = new List<Course>();

      public List<StudentCourse> Courses { get; set; } = new List<StudentCourse>();
   }
}
