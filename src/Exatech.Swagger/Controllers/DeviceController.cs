using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Exatech.Swagger.Models;
using Swashbuckle.Swagger.Annotations;

namespace Exatech.Swagger.Controllers
{
	/// <summary>
	/// Device Contolller
	/// </summary>
	[RoutePrefix("api/v1.0")]
	public class DeviceController : ApiController
    {
		/// <summary>
		/// Register a new device
		/// </summary>
		/// <param name="device">The device you would like to add</param>
		/// <returns>The device ID and Symetrics keys</returns>
		[HttpPost]
		[Route("device")]
		[SwaggerResponseRemoveDefaults]
		[SwaggerResponse(HttpStatusCode.Created, "The device was sucessfuly created", typeof(Device))]
		[SwaggerResponse(HttpStatusCode.BadRequest, "One or more device properties have errors or are missing", typeof(BadRequestModel))]
		[SwaggerResponse(HttpStatusCode.Conflict, "A device with the same serial number already exists")]
		[SwaggerOperation("Create")]
		public async Task<IHttpActionResult> Create(DeviceResgisteringModel device) {
			if (!ModelState.IsValid) {
				return Content(HttpStatusCode.BadRequest, new BadRequestModel("Error while validating data", ModelState));
			}
			return Created($"/device/{Guid.NewGuid()}", new Device());
		}

		/// <summary>
		/// Update the device
		/// </summary>
		/// <param name="deviceId">The device you would like to update</param>
		/// <param name="device">The new values</param>
		/// <returns></returns>
		[HttpPut]
		[Route("device/{deviceId}")]
		[SwaggerResponseRemoveDefaults]
		[SwaggerResponse(HttpStatusCode.OK, "The device status was sucessfuly changed")]
		[SwaggerResponse(HttpStatusCode.NotFound, "The device was not found")]
		[SwaggerResponse(HttpStatusCode.BadRequest, "One or more device properties have errors or are missing", typeof(BadRequestModel))]
		[SwaggerResponse(HttpStatusCode.Forbidden, "You do not have right to change the state of this device")]
		[SwaggerOperation("UpdateDevice")]
		public async Task<IHttpActionResult> Update(Guid? deviceId, Device device) {
			if (!ModelState.IsValid) {
				return Content(HttpStatusCode.BadRequest, new BadRequestModel("Error while validating data", ModelState));
			}
			return Ok(device);
		}

		/// <summary>
		/// Remove a device
		/// </summary>
		/// <param name="deviceId">The device to remove</param>
		/// <returns></returns>
		[HttpDelete]
		[Route("device/{deviceId}")]
		[SwaggerResponseRemoveDefaults]
		[SwaggerResponse(HttpStatusCode.OK, "The device was removed")]
		[SwaggerResponse(HttpStatusCode.NotFound, "The device was not found")]
		[SwaggerResponse(HttpStatusCode.Forbidden, "You do not have right to remove this device")]
		[SwaggerOperation("RemoveDevice")]
		public async Task<IHttpActionResult> RemoveDevice(Guid? deviceId) {
			return Ok();
		}

		/// <summary>
		/// Get the full list of devices
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("devices")]
		[SwaggerResponseRemoveDefaults]
		[SwaggerResponse(HttpStatusCode.OK, "your list of devices registered", typeof(List<Device>))]
		[SwaggerResponse(HttpStatusCode.NoContent, "You have no device registered")]
		[SwaggerOperation("GetDevices")]
		public async Task<IHttpActionResult> GetDevices() {
		    return Ok(new List<Device>());
	    }

		/// <summary>
		/// Get a specific device
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("device/{id}")]
		[SwaggerResponseRemoveDefaults]
		[SwaggerResponse(HttpStatusCode.OK, "The informations about the device", typeof(Device))]
		[SwaggerResponse(HttpStatusCode.NotFound, "The device does not exists")]
		[SwaggerResponse(HttpStatusCode.Forbidden, "You do not have right to remove this device")]
		[SwaggerOperation("GetDevice")]
		public async Task<IHttpActionResult> GetDevice() {
			return Ok(new List<Device>());
		}
	}
}
