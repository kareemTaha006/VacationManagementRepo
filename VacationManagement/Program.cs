using Microsoft.EntityFrameworkCore;
using VacationManagement.Data;
using VacationManagement.Models;
using VacationManagement.Services;

namespace VacationManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<VacationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VacationConn")));
            builder.Services.AddScoped<ICrud<Department>,DepartmentService>();
            builder.Services.AddScoped<ICrud<Employee>, EmployeeService>();
            builder.Services.AddScoped<ICrud<VacationType>,VacationTypeService>();
          
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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}