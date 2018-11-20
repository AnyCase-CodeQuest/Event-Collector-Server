using EventCollectorServer.Database.Entities;
using EventCollectorServer.Database.Interfaces;

namespace EventCollectorServer.Database.Core
{
	public class UnitOfWork: IUnitOfWork
	{
		public UnitOfWork()
		{

		}

		public IRepository<Device> Devices { get; }

		public IRepository<DeviceMessage> DeviceMessages { get; }
	}
}
