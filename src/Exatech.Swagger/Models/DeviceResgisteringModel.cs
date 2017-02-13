using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;

namespace Exatech.Swagger.Models {
	public class DeviceResgisteringModel {
		/// <summary>
		/// The serial number of your device
		/// </summary>
		[StringLength(50, ErrorMessage = "The SerialNumber must be less than 50 characters")]
		[Required(ErrorMessage = "SerialNumber is mandatory")]
		public string SerialNumber { get; set; }

		/// <summary>
		/// The Type of your device
		/// </summary>
		[Required(ErrorMessage = "Type is mandatory")]
		public DeviceType Type { get; set; }

		/// <summary>
		/// The MacAddress of your device
		/// </summary>
		[StringLength(40, ErrorMessage = "MacAddress must be less than 40 characters")]
		[RegularExpression("^([0-9A-Fa-f]{2}[:-]){5,7}([0-9A-Fa-f]{2})$", ErrorMessage = "Bad MacAddress format. Must be like : '00:00:00:00:00:00'")]
		public string MacAddress { get; set; }

		/// <summary>
		/// The Firmware version of your device
		/// </summary>
		[Required(ErrorMessage = "FirmwareVersion is mandatory")]
		[StringLength(20, ErrorMessage = "FirmwareVersion must be less than 20 characters")]
		public string FirmwareVersion { get; set; }

		/// <summary>
		/// The battery level of your device
		/// </summary>
		[Range(0, 100, ErrorMessage = "BatteryLevel should be between 0 and 100 (%)")]
		public int BatteryLevel { get; set; }

		/// <summary>
		/// Metadatas can be used to add more properties to your devices
		/// </summary>
		public IEnumerable<JObject> Metadatas { get; set; }

	}
}