using Autofac;
using EventCollectorServer.Database.Core;
using EventCollectorServer.Database.Interfaces;
using EventCollectorServer.Database.MongoDB;

namespace EventCollectorServer.DependencyInjection.Modules
{
	/// <summary>
	/// Registers the business services.
	/// </summary>
	/// <seealso cref="Module" />
	internal class DatabaseModule : Module
	{
		/// <inheritdoc />
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder
				.RegisterType<UnitOfWork>()
				.As<IUnitOfWork>()
				.InstancePerLifetimeScope();

			builder
				.RegisterType<EventCollectorServerContext>()
				.As<IEventCollectorServerContext>()
				.InstancePerLifetimeScope();

			builder
				.RegisterAssemblyTypes(typeof(MongoRepository<>).Assembly)
				.AsImplementedInterfaces()
				.InstancePerLifetimeScope();
		}
	}
}
