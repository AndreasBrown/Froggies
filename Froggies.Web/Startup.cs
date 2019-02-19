using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Froggies.Web
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});


			services.Configure<RazorViewEngineOptions>(o =>
			{
				o.AreaViewLocationFormats.Add("/Areas/{2}/{0}/{0}" + RazorViewEngine.ViewExtension); // Partials
				o.AreaViewLocationFormats.Add("/Areas/{2}/{0}"	   + RazorViewEngine.ViewExtension); // ViewComponents
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}
		
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error"); // TODO: Создать страницу ошибки.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseCookiePolicy();

			var typeProvider = new FileExtensionContentTypeProvider();
			typeProvider.Mappings[".less"] = "text/css";

			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory() + "/Areas"),
				ContentTypeProvider = typeProvider,
				RequestPath = "/Areas"
			});

			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory() + "/Content"),
				ContentTypeProvider = typeProvider,
				RequestPath = "/Content"
			});

			app.UseMvc(routes =>
			{
				routes.MapRoute(name: "area", template: "{area:exists}/{controller}/{action}/{id?}");
			});

		}
	}
}
