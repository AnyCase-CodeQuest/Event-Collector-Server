using System.Threading;
using System.Threading.Tasks;

namespace EventCollectorServer.Database.Interfaces
{
	/// <summary>
	/// Base Repositories functionality.
	/// </summary>
	/// <typeparam name="TEntity">Entity type.</typeparam>
	public interface IRepository<in TEntity> where TEntity : class
	{
		/// <summary>
		/// Inserts the asynchronous.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns></returns>
		Task InsertAsync(TEntity entity, CancellationToken? cancellationToken);
	}
}
