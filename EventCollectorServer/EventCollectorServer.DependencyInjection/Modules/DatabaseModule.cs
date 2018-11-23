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
				.RegisterGeneric(typeof(MongoRepository<>))
				.As(typeof(IRepository<>))
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
