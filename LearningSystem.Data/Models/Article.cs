namespace LearningSystem.Data.Models
{
   using System;
   using System.ComponentModel.DataAnnotations;
   using Web.Models;
   using static DataConstants;

   public class Article
   {
      public int Id { get; set; }

      [Required]
      [MinLength(ArticleTitleMinLenght)]
      [MaxLength(ArticleTileMaxLenght)]
      public  string Title { get; set; }
      [Required]
      [MaxLength(5000)]
      public string Content { get; set; }

      public DateTime PublishDate { get; set; }

      public string AuthorId { get; set; }

      public User Author { get; set; }
   }
}
