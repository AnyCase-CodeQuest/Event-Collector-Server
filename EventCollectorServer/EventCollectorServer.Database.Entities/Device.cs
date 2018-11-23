using System;
using EventCollectorServer.Database.Entities.Enums;

namespace EventCollectorServer.Database.Entities
{
	public class Device
	{
		public Guid Id { get; set; }

		public DeviceType Type { get; set; }

		public DeviceStatus Status { get; set; }

		public DateTime LastPingOn { get; set; }

		public DateTime RegisteredOn { get; set; }
	}
}
