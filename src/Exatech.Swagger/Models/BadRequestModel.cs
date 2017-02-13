using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;

namespace Exatech.Swagger.Models {
	public class BadRequestModel {
		/// <summary>
		/// Message explaining the bad request error
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// The list of errors that prevent the validation of your request
		/// </summary>
		public List<string> ModelErrors { get; set; }

		public BadRequestModel(string message, ModelStateDictionary modelState) {
			Message = message;
			var modelStatesError = modelState.Select(m => m.Value).SelectMany(e => e.Errors);
			ModelErrors = new List<string>();
			foreach (var state in modelStatesError) {
				if (!string.IsNullOrEmpty(state.ErrorMessage))
					ModelErrors.Add(state.ErrorMessage);
				else {
					var index = state.Exception?.Message.IndexOf("', line", StringComparison.Ordinal);
					var exceptionMessage = state.Exception?.Message;
					if (index.HasValue && index.Value >= 0) {
						exceptionMessage = state.Exception?.Message.Substring(0, index.Value);
					}
					ModelErrors.Add(exceptionMessage);
				}
			}
		}

	}
}