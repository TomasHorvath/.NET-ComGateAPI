using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THsoftware.ComGate.Core.Domain.Models;

namespace THsoftware.ComGate.WebClient.Models
{
	public class AdvancedPaymentViewModel
	{
		[Required]
		public decimal Price { get; set; }
		[Required]
		public string ReferenceId { get; set; }
		[Required]
		public string Label { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Name { get; set; }

		public bool PreAuth { get; set; }

		public List<SelectListItem> PaymentMethods { get; set; }
		public Core.Domain.Enums.PaymentMethods SelectedMethod { get; set; }

		public List<SelectListItem> Currencies { get; set; }
		public Core.Domain.Enums.Currency SelectedCurrency { get; set; }

		public bool EetReport { get; set; }
		public Method[] Methods { get; internal set; }

		public string EETData { get; set; }
	}
}