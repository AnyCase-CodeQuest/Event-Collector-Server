using EventCollectorServer.Database.Entities;

namespace EventCollectorServer.Database.Interfaces
{
	/// <summary>
	/// Unit of Work for a Database access.
	/// </summary>
	public interface IUnitOfWork
	{
		IRepository<Device> Devices { get; }

		IRepository<DeviceMessage> DeviceMessages { get; }
	}
}
