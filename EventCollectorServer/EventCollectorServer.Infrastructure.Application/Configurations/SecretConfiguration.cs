using EventCollectorServer.Infrastructure.Interfaces.Configurations;

namespace EventCollectorServer.Infrastructure.Application.Configurations
{
	/// <inheritdoc />
	public class SecretConfiguration : ISecretConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SecretConfiguration"/> class.
		/// </summary>
		public SecretConfiguration()
		{
		}

		/// <inheritdoc />
		public string ConnectionString { get; set; }
	}
}
