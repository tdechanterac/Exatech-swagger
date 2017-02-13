using System;

namespace Exatech.Swagger.Models {
	public class InternalServerModel {
		/// <summary>
		/// Message of internal error
		/// </summary>
		public string Message { get; set; }
		/// <summary>
		/// The correlationId to use to get logs
		/// </summary>
		public Guid CorrelationId { get; set; }
		public InternalServerModel(Guid correlationId) {
			CorrelationId = correlationId;
			Message = "An error occured, and we are sorry. You can give us the correlationId to investigate on this problem";
		}
	}
}