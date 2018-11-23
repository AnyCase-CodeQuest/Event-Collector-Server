using Autofac;
using EventCollectorServer.Infrastructure.Application;

namespace EventCollectorServer.DependencyInjection.Modules
{
	/// <summary>
	/// Registers application dependencies.
	/// </summary>
	/// <seealso cref="Module" />
	internal class ApplicationModule : Module
	{
		/// <inheritdoc />
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder
				.RegisterAssemblyTypes(typeof(ApplicationContext).Assembly)
				.Where(type => type.IsInNamespaceOf<ApplicationContext>())
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}
	}
}
