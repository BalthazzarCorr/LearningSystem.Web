namespace LearningSystem.Data.Models
{
   using System;
   using System.Collections.Generic;
   using Web.Models;

   public class Course
   {
      public int Id { get; set; }

      public string Description { get; set; }

      public string TrainerId { get; set; }

      public DateTime StartDate { get; set; }

      public DateTime EndDate { get; set; }

      public User Trainer { get; set; }

      public List<StudentCourse> Studnets { get; set; } = new List<StudentCourse>();
   }
}
