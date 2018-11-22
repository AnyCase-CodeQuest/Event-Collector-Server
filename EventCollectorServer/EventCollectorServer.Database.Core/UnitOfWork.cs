using System;
using EventCollectorServer.Database.Entities;
using EventCollectorServer.Database.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EventCollectorServer.Database.Core
{
	public class UnitOfWork: IUnitOfWork
	{
		private readonly IServiceProvider serviceProvider;

		public UnitOfWork(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public IRepository<Device> Devices => serviceProvider.GetRequiredService<IRepository<Device>>();

		public IRepository<DeviceMessage> DeviceMessages => serviceProvider.GetRequiredService<IRepository<DeviceMessage>>();
	}
}
