using EventCollectorServer.Database.Entities;
using EventCollectorServer.Database.Interfaces.Repositories;

namespace EventCollectorServer.Database.Interfaces
{
	/// <summary>
	/// Unit of Work for a Database access.
	/// </summary>
	public interface IUnitOfWork
	{
		IRepository<Device> Devices { get; }

		IDeviceMessagesRepository DeviceMessages { get; }
	}
}
