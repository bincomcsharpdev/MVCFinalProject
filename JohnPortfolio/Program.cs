using JohnPortfolio.Data;
using JohnPortfolio.Interfaces;
using JohnPortfolio.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JohnPortfolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContextPool<BincomDb>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:Default"), sqlOptions => sqlOptions.CommandTimeout(120));
            });

            builder.Services.AddScoped<ICarRepository, CarRepository>();
            // Add services to the container to pipeline.
            builder.Services.AddControllersWithViews();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Car}/{action=Index}/{id?}");

            app.Run();
        }
    }
}