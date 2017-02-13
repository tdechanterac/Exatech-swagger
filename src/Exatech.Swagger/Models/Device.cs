using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Exatech.Swagger.Models {

	public class Device {
		/// <summary>
		/// The device Id.
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// The owner Id of the device
		/// </summary>
		public Guid OwnerId { get; set; }
		/// <summary>
		/// The serial number of your device
		/// </summary>
		public string SerialNumber { get; set; }
		/// <summary>
		/// The current status of you device
		/// </summary>
		public DeviceStatus Status { get; set; }
		/// <summary>
		/// The date of registration
		/// </summary>
		public DateTime RegistrationDate { get; set; }

		/// <summary>
		/// The Type of your device
		/// </summary>
		public DeviceType Type { get; set; }

		/// <summary>
		/// The MacAddress of your device
		/// </summary>
		public string MacAddress { get; set; }

		/// <summary>
		/// The Firmware version of your device
		/// </summary>
		public string FirmwareVersion { get; set; }

		/// <summary>
		/// The battery level of your device
		/// </summary>
		public int BatteryLevel { get; set; }

		/// <summary>
		/// Metadatas can be used to add more properties to your devices
		/// </summary>
		public IEnumerable<JObject> Metadatas { get; set; }
	}

	public enum DeviceStatus {
		Registered,
		On,
		Off,
		Failure,
	}

	public enum DeviceType {
		Plug,
		Light,
		Thermostat,
	}
}