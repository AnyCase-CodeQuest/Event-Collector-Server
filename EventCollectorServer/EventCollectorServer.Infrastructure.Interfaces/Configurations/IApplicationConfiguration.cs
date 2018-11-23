namespace EventCollectorServer.Infrastructure.Interfaces.Configurations
{
	/// <summary>
	/// Represents the application configuration.
	/// </summary>
	public interface IApplicationConfiguration
	{
		/// <summary>
		/// Gets the secret configuration.
		/// </summary>
		ISecretConfiguration Secrets { get; }
	}
}
