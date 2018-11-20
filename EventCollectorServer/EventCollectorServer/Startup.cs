using System;
using EventCollectorServer.DependencyInjection;
using EventCollectorServer.Infrastructure.Interfaces.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventCollectorServer.Api
{
	public class Startup
	{
		private readonly IConfiguration configuration;

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;

			this.configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			ServiceProviderBuilder serviceProviderBuilder = new ServiceProviderBuilder();
			IServiceProvider serviceProvider = serviceProviderBuilder.Build(services);

			configuration.Bind(serviceProvider.GetRequiredService<IApplicationConfiguration>());

			return serviceProvider;
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}
