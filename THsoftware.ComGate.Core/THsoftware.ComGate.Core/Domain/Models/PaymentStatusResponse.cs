using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Models
{
	public class PaymentStatusResponse
	{
		public string merchant { get; set; }
		public string test { get; set; }
		public string price { get; set; }

		public Domain.Enums.Currency Currency { get; set; }
		public Domain.Enums.PaymentState Status { get; set; }
		public Domain.Models.EetData EET { get; set; }


		public string label { get; set; }
		public string refId { get; set; }
		public string method { get; set; }
		public string email { get; set; }
		public string name { get; set; }
		public string transId { get; set; }
		public string secret { get; set; }
		public string fee { get; set; }
		public string vs { get; set; }
		public string payerId { get; set; }
		public string payerName { get; set; }
		public string payerAcc { get; set; }
		public string account { get; set; }
		public string phone { get; set; }
		public string eetData { get; set; }

	}
}
