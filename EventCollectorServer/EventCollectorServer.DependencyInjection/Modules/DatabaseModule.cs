using Autofac;
using EventCollectorServer.Database.Core;
using EventCollectorServer.Database.Interfaces;
using EventCollectorServer.Database.Interfaces.Repositories;
using EventCollectorServer.Database.MongoDB;
using EventCollectorServer.Database.MongoDB.Configurations;
using EventCollectorServer.Database.MongoDB.Repositories;

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
				.RegisterGeneric(typeof(MongoRepository<>))
				.As(typeof(IRepository<>))
				.InstancePerLifetimeScope();

			builder.RegisterAssemblyTypes(typeof(DeviceConfiguration).Assembly)
				.As(typeof(IEntityMapConfiguration))
				.InstancePerLifetimeScope();

			builder
				.RegisterType<DeviceMessagesRepository>()
				.As<IDeviceMessagesRepository>()
				.InstancePerLifetimeScope();

			// This can be uncommented when will be implemented any specific repository
			// https://andrewlock.net/how-to-register-a-service-with-multiple-interfaces-for-in-asp-net-core-di/
			//builder
			//	.RegisterAssemblyTypes(typeof(MongoRepository<>).Assembly, typeof(IRepository<>).Assembly)
			//		.Where(t => t.Name.EndsWith("Repository"))
			//	.AsImplementedInterfaces()
			//	.InstancePerLifetimeScope();
		}
	}
}
