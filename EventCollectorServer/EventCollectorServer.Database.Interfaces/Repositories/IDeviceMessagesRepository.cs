using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventCollectorServer.Database.Entities;

namespace EventCollectorServer.Database.Interfaces.Repositories
{
	public interface IDeviceMessagesRepository: IRepository<DeviceMessage>
	{
		Task<IList<DeviceMessage>> Get(Guid deviceId, DateTime? from = null, DateTime? to = null);
	}
}
