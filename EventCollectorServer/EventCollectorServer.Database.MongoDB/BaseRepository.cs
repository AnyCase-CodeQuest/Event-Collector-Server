using System;
using System.Collections.Generic;
using System.Text;
using EventCollectorServer.Database.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EventCollectorServer.Database.MongoDB
{
	public class MongoRepository<TEntity> : IRepository<TEntity>
	{
		private readonly string _connectionString;
		private readonly string _databaseName;

		private readonly MongoClient _client;

		public MongoRepository(ISettings)
		{
			_keys = keys;
			_connectionString = connectionString;
			_databaseName = databaseName;

			_client = new MongoClient(connectionString);
			_server = _client.GetServer();
			_db = _server.GetDatabase(databaseName);
		}

		public TEntity Single<TEntity>(object key) where TEntity : class, new()
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
