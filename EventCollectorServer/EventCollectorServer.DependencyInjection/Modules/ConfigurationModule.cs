using Autofac;
using EventCollectorServer.Infrastructure.Application.Configurations;

namespace EventCollectorServer.DependencyInjection.Modules
{
	/// <summary>
	/// Registers the configurations.
	/// </summary>
	/// <seealso cref="Module" />
	internal class ConfigurationModule : Module
	{
		/// <inheritdoc />
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder
				.RegisterAssemblyTypes(typeof(ApplicationConfiguration).Assembly)
				.Where(type => type.IsInNamespaceOf<ApplicationConfiguration>())
				.AsImplementedInterfaces()
				.SingleInstance();
		}
	}
}
