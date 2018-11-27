using System;
using EventCollectorServer.Database.Entities;
using EventCollectorServer.Database.Interfaces;
using EventCollectorServer.Database.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EventCollectorServer.Database.Core
{
	public class UnitOfWork: IUnitOfWork
	{
		private readonly IServiceProvider serviceProvider;

		public UnitOfWork(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;

			var requiredService = this.serviceProvider.GetRequiredService<IRepository<Device>>();
		}

		public IRepository<Device> Devices => serviceProvider.GetRequiredService<IRepository<Device>>();

		public IDeviceMessagesRepository DeviceMessages => serviceProvider.GetRequiredService<IDeviceMessagesRepository>();
	}
}
