using System;
using System.Collections.Generic;
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

		// GET: api/OfficeClimateSensors?deviceId=..
		/// <summary>
		/// Gets <see cref="DeviceMessage"/> list by provided arguments.
		/// </summary>
		/// <param name="deviceId">The  <see cref="Guid"/> device identifier.</param>
		/// <param name="from">From <see cref="DateTime"/>. Not required parameter.</param>
		/// <param name="to">To <see cref="DateTime"/>.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">Difference between 'from' and 'to' dates should be less than one day.</exception>
		[HttpGet]
		public async Task<IList<DeviceMessage>> Get([FromQuery] Guid deviceId, [FromQuery] DateTime? from = null, [FromQuery] DateTime? to = null)
		{
			if (from.HasValue && to.HasValue && (from.Value - to.Value).TotalDays > 1)
			{
				throw new ArgumentException("Difference between 'from' and 'to' dates should be less than one day.");
			}


			return await unitOfWork.DeviceMessages.Get(deviceId, from, to);
		}
	}
}
