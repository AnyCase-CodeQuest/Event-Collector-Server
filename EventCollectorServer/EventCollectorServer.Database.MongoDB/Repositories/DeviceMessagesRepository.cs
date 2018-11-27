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
			int findLimit = 1;

			FilterDefinition<DeviceMessage> definition = Builders<DeviceMessage>.Filter.Eq(
				deviceMessage => deviceMessage.DeviceId,
				deviceId);

			SortDefinition<DeviceMessage> sortDefinition
				= Builders<DeviceMessage>.Sort.Descending(deviceMessage => deviceMessage.CreatedOn);

			if (from.HasValue)
			{
				definition = Builders<DeviceMessage>.Filter.And(
					definition,
					Builders<DeviceMessage>.Filter.Gte(deviceMessage => deviceMessage.CreatedOn, from));

				findLimit = 5000;
			}

			if (to.HasValue)
			{
				definition = Builders<DeviceMessage>.Filter.And(
					definition,
					Builders<DeviceMessage>.Filter.Lte(deviceMessage => deviceMessage.CreatedOn, to));

				findLimit = 5000;
			}

			FindOptions<DeviceMessage, DeviceMessage> findOptions = new FindOptions<DeviceMessage, DeviceMessage>
			{
				Limit = findLimit,
				Sort = sortDefinition
			};

			IAsyncCursor<DeviceMessage> cursor = await Collection.FindAsync(definition, findOptions);
			List<DeviceMessage> result = cursor.ToList();
			return result;
		}
	}
}
