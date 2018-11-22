namespace EventCollectorServer.Api.Contracts
{
	public class OfficeClimateSensorsDataContract
	{
		public string DeviceId { get; set; }

		public int CO2 { get; set; }

		public float Temperature { get; set; }

		public float Humidity { get; set; }
	}
}
