using ExpenseWalletTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseWalletTracker
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// DI
			builder.Services.AddDbContext<ApplicationDbContext>(options => 
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
				pattern: "{controller=Dashboard}/{action=Index}/{id?}");

			app.Run();
		}
	}
}