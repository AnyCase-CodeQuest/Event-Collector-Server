using System;
using System.Collections.Generic;
using System.Text;
using EventCollectorServer.Database.Interfaces;
using EventCollectorServer.Infrastructure.Interfaces.Configurations;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EventCollectorServer.Database.MongoDB
{
	public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private readonly IApplicationConfiguration applicationConfiguration;
		private readonly string connectionString;

		private readonly MongoClient client;

		public MongoRepository(IApplicationConfiguration applicationConfiguration)
		{
			connectionString = applicationConfiguration.Secrets.ConnectionString;

			client = new MongoClient(connectionString);
		}

		public TEntity Single(object key) where TEntity : class, new()
		{
			var collection = GetCollection<TEntity>();
			var query = new QueryDocument("_id", BsonValue.Create(key));
			var entity = collection.FindOneAs<TEntity>(query);

			if (entity == null)
				throw new NullReferenceException("Document with key '" + key + "' not found.");

			return entity;
		}

		public IEnumerable<TEntity> All<TEntity>() where TEntity : class, new()
		{
			var collection = GetCollection<TEntity>();
			var entity = collection.FindAllAs<TEntity>();
			return entity;
		}

		public bool Exists<TEntity>(object key) where TEntity : class, new()
		{
			var collection = GetCollection<TEntity>();
			var query = new QueryDocument("_id", BsonValue.Create(key));
			var entity = collection.FindOneAs<TEntity>(query);
			return (entity != null);
		}

		public void Save<TEntity>(TEntity item) where TEntity : class, new()
		{
			var collection = GetCollection<TEntity>();
			collection.Save(item);
		}

		public void Delete<TEntity>(object key) where TEntity : class, new()
		{
			var collection = GetCollection<TEntity>();
			var query = new QueryDocument("_id", BsonValue.Create(key));
			collection.Remove(query);
		}

		private MongoCollection GetCollection<TEntity>()
		{
			return _db.GetCollection(typeof(TEntity).Name);
		}
	}
}
