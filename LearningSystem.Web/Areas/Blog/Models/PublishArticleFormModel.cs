namespace LearningSystem.Web.Areas.Blog.Models
{
   using System;
   using System.ComponentModel.DataAnnotations;
   using static  Data.DataConstants;

   public class PublishArticleFormModel
   {
      [Required]
      [MinLength(ArticleTitleMinLenght)]
      [MaxLength(ArticleTileMaxLenght)]
      public string Title { get; set; }

      [Required]
      public string Content { get; set; }

      [DataType(DataType.Date)]
      public DateTime PublishDate { get; set; }

   }
}