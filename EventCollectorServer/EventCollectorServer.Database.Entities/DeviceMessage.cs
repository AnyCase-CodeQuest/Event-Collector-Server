using System;
using EventCollectorServer.Database.Entities.Enums;

namespace EventCollectorServer.Database.Entities
{
	public class DeviceMessage
	{
		public Guid Id { get; set; }

		public Guid DeviceId { get; set; }

		public DateTime CreatedOn { get; set; }

		public DeviceMessageDirection Direction { get; set; }

		public DeviceMessageData Data { get; set; }
	}
}
