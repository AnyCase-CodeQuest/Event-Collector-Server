using System;

namespace EventCollectorServer.Database.Entities
{
	public class DeviceEvent
	{
		public Guid Id { get; set; }

		public DateTime CreatedOn { get; set; }

		public DeviceEventData Data { get; set; }
	}
}
