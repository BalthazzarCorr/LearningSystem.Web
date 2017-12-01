namespace LearningSystem.Web
{
   using AutoMapper;
   using Data;
   using Infrastructure.Extensions;
   using Models;
   using Services;
   using Microsoft.AspNetCore.Builder;
   using Microsoft.AspNetCore.Hosting;
   using Microsoft.AspNetCore.Identity;
   using Microsoft.EntityFrameworkCore;
   using Microsoft.Extensions.Configuration;
   using Microsoft.Extensions.DependencyInjection;


   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddDbContext<LearningSystemDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

       

         services.AddIdentity<User, IdentityRole>(options =>
            {
               options.Password.RequireDigit = false;
               options.Password.RequireLowercase = false;
               options.Password.RequireUppercase = false;
               options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<LearningSystemDbContext>()
            .AddDefaultTokenProviders();

         

         services.AddAutoMapper();
         services.AddMvc();
         services.AddAntiforgery();
         services.AddDomainServices();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
            app.UseDatabaseErrorPage();
         }
         else
         {
            app.UseExceptionHandler("/Home/Error");
         }

         app.UseStaticFiles();


         app.UseAuthentication();

         app.UseDatabaseMigration();

         app.UseMvc(routes =>
         {
            routes.MapRoute(
               name: "areas",
               template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            routes.MapRoute(
               name: "default",
               template: "{controller=Home}/{action=Index}/{id?}"
               );
         });
      }
   }
}
