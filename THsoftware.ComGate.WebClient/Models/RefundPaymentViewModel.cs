using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THsoftware.ComGate.WebClient.Models
{
	public class RefundPaymentViewModel
	{
		public string TransactionId { get; set; }
		public decimal Amount { get; set; }
		public Core.Domain.Enums.Currency Currency { get; set; }
		public List<SelectListItem> Currencies { get; set; }
	}
}