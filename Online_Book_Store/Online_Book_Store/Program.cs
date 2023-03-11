using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Controllers.DB;

namespace Online_Book_Store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<BookStoreContext>(option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("ConnectionString")
                ));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static object GetUseSqlServer(DbContextOptionsBuilder option)
        {
            return option.UseSqlServer();
        }
    }
}