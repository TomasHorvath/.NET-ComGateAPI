using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Models
{
	public class PaymentStatusRequest : API.BaseComGateRequest
	{
	
		#region Fluent API settings


		public PaymentStatusRequest SetMerchant(string merchant)
		{
			this.Merchant = merchant;
			return this;
		}

		public PaymentStatusRequest SetSecret(string secret)
		{
			this.Secret = secret;
			return this;
		}

		public PaymentStatusRequest SetTransactionId(string transId)
		{
			this.TransactionID = transId;
			return this;
		}
		#endregion

	}
}
