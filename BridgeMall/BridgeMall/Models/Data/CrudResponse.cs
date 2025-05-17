using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeMall.Models.Data
{
	public class CrudResponse: Response
	{
		public CrudResponse()
		{
				
		}
		public CrudResponse(bool success, string message)
		{
			Success = success;
			Message = message;
		}
		public CrudResponse(bool success, string message, string reason)
		{
			Success = success;
			Message = message;
			Reason = reason;
		}
		public string Reason { get; set; } = string.Empty;
	}
}
