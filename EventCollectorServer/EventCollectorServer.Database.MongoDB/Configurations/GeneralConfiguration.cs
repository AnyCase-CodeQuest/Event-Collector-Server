using System;
using EventCollectorServer.Database.Interfaces;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace EventCollectorServer.Database.MongoDB.Configurations
{
	public class GeneralConfiguration : IEntityMapConfiguration
	{
		public void Configure()
		{
			BsonSerializer.RegisterIdGenerator(
				typeof(Guid),
				CombGuidGenerator.Instance
			);
		}
	}
}
