using System.Threading;
using System.Threading.Tasks;
using EventCollectorServer.Database.Interfaces;
using EventCollectorServer.Infrastructure.Interfaces.Configurations;
using MongoDB.Driver;

namespace EventCollectorServer.Database.MongoDB
{
	public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
	{
		protected MongoClient Client { get; }
		protected IMongoDatabase Database { get; }
		protected IMongoCollection<TEntity> Collection { get; }

		public MongoRepository(
			IApplicationConfiguration applicationConfiguration,
			string collectionName = null)
		{
			string connectionString = applicationConfiguration.Secrets.ConnectionString;
			string databaseName = applicationConfiguration.Secrets.DatabaseName;

			Client = new MongoClient(connectionString);
			Database = Client.GetDatabase(databaseName);

			collectionName = collectionName ?? $"{typeof(TEntity).Name}s" ;
			Collection = Database.GetCollection<TEntity>(collectionName);
		}

		/// <inheritdoc cref="IRepository{TEntity}"/>
		public async Task InsertAsync(TEntity entity, CancellationToken? cancellationToken = null)
		{
			await Collection.InsertOneAsync(entity, new InsertOneOptions(), cancellationToken ?? CancellationToken.None);
		}

		//public TEntity Single(object key)
		//{
		//	var collection = GetCollection<TEntity>();
		//	var query = new QueryDocument("_id", BsonValue.Create(key));
		//	var entity = collection.FindOneAs<TEntity>(query);

		//	if (entity == null)
		//		throw new NullReferenceException("Document with key '" + key + "' not found.");

		//	return entity;
		//}

		//public IEnumerable<TEntity> All<TEntity>() where TEntity : class, new()
		//{
		//	var collection = GetCollection<TEntity>();
		//	var entity = collection.FindAllAs<TEntity>();
		//	return entity;
		//}

		//public bool Exists<TEntity>(object key) where TEntity : class, new()
		//{
		//	var collection = GetCollection<TEntity>();
		//	var query = new QueryDocument("_id", BsonValue.Create(key));
		//	var entity = collection.FindOneAs<TEntity>(query);
		//	return (entity != null);
		//}

		//public void Save<TEntity>(TEntity item) where TEntity : class, new()
		//{
		//	var collection = GetCollection<TEntity>();
		//	collection.Save(item);
		//}

		//public void Delete<TEntity>(object key) where TEntity : class, new()
		//{
		//	var collection = GetCollection<TEntity>();
		//	var query = new QueryDocument("_id", BsonValue.Create(key));
		//	collection.Remove(query);
		//}

		//private MongoCollection GetCollection<TEntity>()
		//{
		//	return _db.GetCollection(typeof(TEntity).Name);
		//}
	}
}
