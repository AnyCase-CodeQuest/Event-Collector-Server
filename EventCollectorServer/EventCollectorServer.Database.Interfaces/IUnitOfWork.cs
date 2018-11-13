using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventCollectorServer.Database.Interfaces
{
	/// <summary>
	/// Unit of Work for a Database access.
	/// </summary>
	public interface IUnitOfWork
	{
		/// <summary>
		/// Gets <see cref="IManageConversationLinkRepository"/>.
		/// </summary>
		//IManageConversationLinkRepository ManageConversationLinks { get; }

		/// <summary>
		/// Asynchronously saves all changes made in this context to the database.
		/// </summary>
		/// <returns>
		///     A task that represents the asynchronous save operation. The task result contains the
		///     number of state entries written to the database.
		/// </returns>
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
}
