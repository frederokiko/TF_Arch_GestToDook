using TF_Arch_GestToDo.Dal.Repositories;
using TF_Arch_GestToDo.Dal.Services;
using Tools.Ado;

namespace TF_Arch_GestToDo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = builder.Configuration;

            // Add services to the container.
            IServiceCollection services = builder.Services;
            services.AddControllersWithViews();
            services.AddScoped(sp => new Connection(configuration.GetConnectionString("Database")));
            services.AddScoped<IToDoRepository, ToDoRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/ShowError");
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