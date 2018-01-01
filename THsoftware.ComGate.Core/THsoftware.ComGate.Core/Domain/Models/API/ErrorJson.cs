using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Models.API
{

	public class ComGateError
	{
		public Error error { get; set; }
	}

	public class Error
	{
		public int code { get; set; }
		public string message { get; set; }
		public string extraMessage { get; set; }
	}

}
