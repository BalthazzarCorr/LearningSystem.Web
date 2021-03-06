﻿namespace LearningSystem.Services.Blog.Models
{
   using System;
   using AutoMapper;
   using Common.Mapping;
   using Data.Models;
   public class ArticleListingModel :IMapFrom<Article>, IHaveCustomMapping
   {
      public int Id { get; set; }

      public string Title { get; set; }

      public DateTime PublishDate { get; set; }

      public string Author { get; set; }

      public void ConfigureMapping(Profile mapper)
         => mapper
            .CreateMap<Article, ArticleListingModel>()
            .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
   }
}