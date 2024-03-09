using Microsoft.EntityFrameworkCore;
using TrainingSystem.Models;
using TrainingSystem.Repository;

namespace TrainingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //add service of dbcontext to register 
            builder.Services.AddDbContext<TrainingSystemContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ts"));
            });

            //add server to register the Irepos
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession( options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(40);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
