using EventCollectorServer.Database.Entities;
using EventCollectorServer.Database.Interfaces;
using MongoDB.Bson.Serialization;

namespace EventCollectorServer.Database.Core.Configurations
{
	public class DeviceConfiguration : IEntityMapConfiguration
	{
		public void Configure()
		{
			BsonClassMap.RegisterClassMap<Device>(classMap =>
			{
				classMap.AutoMap();
				classMap.MapIdMember(member => member.Id);
				classMap.MapMember(member => member.Type);
				classMap.MapMember(member => member.Status);
				classMap.MapMember(member => member.LastPingOn);
				classMap.MapMember(member => member.RegisteredOn);
			});
		}
	}
}
