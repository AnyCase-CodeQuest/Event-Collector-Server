namespace EventCollectorServer.Database.Interfaces
{
	public interface IEventCollectorServerContext
	{
		/// <summary>
		/// Configures database entities mapping.
		/// </summary>
		void Configure();
	}
}
