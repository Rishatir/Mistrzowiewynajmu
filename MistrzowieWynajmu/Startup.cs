using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MistrzowieWynajmu.Models.Database;
using Microsoft.EntityFrameworkCore;
using MistrzowieWynajmu.Models.Repositories;
using MistrzowieWynajmu.Models.Interfaces;

namespace MistrzowieWynajmu
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary> 
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			var dbConnectionString = @"Server=(LocalDB)\MSSQLLocalDB;Database=MistrzowieDB;Trusted_Connection=True;";
			Console.WriteLine(dbConnectionString);
			services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(dbConnectionString));

			services.AddScoped<IPropertyRepository, PropertyRepository>();
			services.AddScoped<IAddressRepository, AddressRepository>();
			services.AddScoped<IOwnerRepository, OwnerRepository>();
		}

		/// <summary> 
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, DatabaseContext dataContext)
		{
			//dataContext.Database.Migrate();
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
				{
					HotModuleReplacement = true
				});
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");

				routes.MapSpaFallbackRoute(
					name: "spa-fallback",
					defaults: new { controller = "Home", action = "Index" });
			});
		}
	}
}
