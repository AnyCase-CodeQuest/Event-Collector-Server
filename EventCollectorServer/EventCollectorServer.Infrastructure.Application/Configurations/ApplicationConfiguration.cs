using EventCollectorServer.Infrastructure.Interfaces.Configurations;

namespace EventCollectorServer.Infrastructure.Application.Configurations
{
	/// <inheritdoc />
	public class ApplicationConfiguration : IApplicationConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationConfiguration"/> class.
		/// </summary>
		/// <param name="secrets">The secrets.</param>
		public ApplicationConfiguration(
			ISecretConfiguration secrets)
		{
			Secrets = secrets;
		}

		/// <inheritdoc />
		public ISecretConfiguration Secrets { get; }
	}
}
