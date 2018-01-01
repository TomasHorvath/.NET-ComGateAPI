using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THsoftware.ComGate.Core.Domain.Enums;

namespace THsoftware.ComGate.Core.Domain.Models
{
	public class PaymentResponse
	{
		public string TransactionId { get; set; }
		public string RedirectUrl { get; set; }
	}
}
