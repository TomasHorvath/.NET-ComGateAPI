using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Models
{

	public class PaymentMethodsResponse
	{
		public Method[] methods { get; set; }
	}

	public class Method
	{
		public string id { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public string logo { get; set; }
	}

}
