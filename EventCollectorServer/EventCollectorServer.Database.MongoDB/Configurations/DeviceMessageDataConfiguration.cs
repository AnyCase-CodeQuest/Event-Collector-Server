using EventCollectorServer.Database.Entities;
using EventCollectorServer.Database.Interfaces;
using MongoDB.Bson.Serialization;

namespace EventCollectorServer.Database.MongoDB.Configurations
{
	public class DeviceMessageDataConfiguration: IEntityMapConfiguration
	{
		public void Configure()
		{
			BsonClassMap.RegisterClassMap<DeviceMessageData>(classMap =>
			{
				classMap.AutoMap();
				classMap.SetIsRootClass(true);
				classMap.MapIdMember(member => member.Id);
			});
		}
	}
}
