namespace EventCollectorServer.Infrastructure.Interfaces.Configurations
{
	/// <summary>
	/// Represents the secret configuration.
	/// </summary>
	public interface ISecretConfiguration
	{
		/// <summary>
		/// Gets or sets the connection string.
		/// </summary>
		string ConnectionString { get; set; }

		/// <summary>
		/// Gets or sets the database name.
		/// </summary>
		string DatabaseName { get; set; }
	}
}
