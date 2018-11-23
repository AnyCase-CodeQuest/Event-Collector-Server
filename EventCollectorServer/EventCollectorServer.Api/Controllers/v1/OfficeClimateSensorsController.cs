using System;
using System.Threading.Tasks;
using EventCollectorServer.Api.Contracts;
using EventCollectorServer.Database.Entities;
using EventCollectorServer.Database.Entities.Enums;
using EventCollectorServer.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventCollectorServer.Api.Controllers.v1
{
	[Route("api/[controller]")]
	[ApiController]
	public class OfficeClimateSensorsController : ControllerBase
	{
		private readonly IUnitOfWork unitOfWork;

		public OfficeClimateSensorsController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		// POST: api/OfficeClimateSensors
		[HttpPost]
		public async Task Post([FromBody] OfficeClimateSensorsDataContract data)
		{
			DeviceMessage deviceMessage = new DeviceMessage();

			if (!Guid.TryParse(data.DeviceId, out Guid deviceId))
			{
				deviceId = Guid.Empty;
			}
			deviceMessage.DeviceId = deviceId;

			deviceMessage.CreatedOn = DateTime.UtcNow;
			deviceMessage.Direction = DeviceMessageDirection.Inbound;
			deviceMessage.Data = new OfficeClimateSensorsSetData
			{
				CO2 = data.CO2,
				Humidity = data.Humidity,
				Temperature = data.Temperature
			};

			await unitOfWork.DeviceMessages.InsertAsync(deviceMessage);
		}
	}
}
