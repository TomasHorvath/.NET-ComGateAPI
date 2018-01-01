using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THsoftware.ComGate.WebClient.Models
{
	public class BasicPaymentViewModel
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
	}
}