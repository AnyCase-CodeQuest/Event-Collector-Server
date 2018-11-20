using System.Collections.Generic;
using EventCollectorServer.Database.Interfaces;

namespace EventCollectorServer.Database.Core
{
	public class EventCollectorServerContext: IEventCollectorServerContext
	{
		private readonly ICollection<IEntityMapConfiguration> entityMapConfigurations;

		public EventCollectorServerContext(ICollection<IEntityMapConfiguration> entityMapConfigurations)
		{
			this.entityMapConfigurations = entityMapConfigurations;
		}

		public void Configure()
		{
			foreach (IEntityMapConfiguration entityMapConfiguration in entityMapConfigurations)
			{
				entityMapConfiguration.Configure();
			}
		}
	}
}
