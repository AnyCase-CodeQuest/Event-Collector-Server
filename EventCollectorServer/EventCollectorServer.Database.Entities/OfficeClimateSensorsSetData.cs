namespace EventCollectorServer.Database.Entities
{
	public class OfficeClimateSensorsSetData: DeviceMessageData
	{
		/// <summary>
		/// CO2 in PPM
		/// </summary>
		public int CO2 { get; set; }

		public float Temperature { get; set; }

		public float Humidity { get; set; }
	}
}
