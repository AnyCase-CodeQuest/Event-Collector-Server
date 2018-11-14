using System;
using EventCollectorServer.Database.Entities;
using EventCollectorServer.Database.Interfaces;
using MongoDB.Bson.Serialization;

namespace EventCollectorServer.Database.MongoDB.Configurations
{
	public class DeviceMessageConfiguration : IEntityMapConfiguration
	{
		public void Configure()
		{
			BsonClassMap.RegisterClassMap<DeviceMessage>(classMap =>
			{
				classMap.AutoMap();
				classMap.MapIdMember(member => member.Id);
				classMap
					.MapMember(member => member.CreatedOn)
					.SetDefaultValue(() => DateTime.UtcNow);
				classMap.MapMember(member => member.Direction);
				classMap.MapMember(member => member.Data);
			});
		}
	}
}
