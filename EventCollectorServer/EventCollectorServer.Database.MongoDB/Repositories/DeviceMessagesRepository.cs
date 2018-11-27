using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventCollectorServer.Database.Entities;
using EventCollectorServer.Database.Interfaces;
using EventCollectorServer.Database.Interfaces.Repositories;
using EventCollectorServer.Infrastructure.Interfaces.Configurations;
using MongoDB.Driver;

namespace EventCollectorServer.Database.MongoDB.Repositories
{
	public class DeviceMessagesRepository: MongoRepository<DeviceMessage>, IDeviceMessagesRepository
	{
		public DeviceMessagesRepository(
			IApplicationConfiguration applicationConfiguration,
			string collectionName = null) : base(applicationConfiguration, collectionName)
		{
		}

		public async Task<IList<DeviceMessage>> Get(Guid deviceId, DateTime? from = null, DateTime? to = null)
		{
			FilterDefinition<DeviceMessage> definition = Builders<DeviceMessage>.Filter.Eq(
				deviceMessage => deviceMessage.DeviceId,
				deviceId);

			if (from.HasValue)
			{
				definition = Builders<DeviceMessage>.Filter.And(
					definition,
					Builders<DeviceMessage>.Filter.Gte(deviceMessage => deviceMessage.CreatedOn, from));
			}

			if (to.HasValue)
			{
				definition = Builders<DeviceMessage>.Filter.And(
					definition,
					Builders<DeviceMessage>.Filter.Lte(deviceMessage => deviceMessage.CreatedOn, to));
			}

			FindOptions<DeviceMessage, DeviceMessage> findOptions = new FindOptions<DeviceMessage, DeviceMessage>();
			findOptions.Limit = 5000;

			IAsyncCursor<DeviceMessage> cursor = await Collection.FindAsync(definition, findOptions);
			List<DeviceMessage> result = cursor.ToList();
			return result;
		}
	}
}
