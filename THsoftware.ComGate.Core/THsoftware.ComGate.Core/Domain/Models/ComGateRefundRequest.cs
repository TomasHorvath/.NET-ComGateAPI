using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Models
{
	
	public class RefundRequest : API.BaseComGateRequest
	{
		public Enums.Currency Currency { get; set; }
		public decimal Amount { get; set; }
		public bool Test { get; set; }


		#region Someone prefer Fluent API settings


		public RefundRequest SetMerchant(string merchant)
		{
			this.Merchant = merchant;
			return this;
		}
		

		public RefundRequest SetSecret(string secret)
		{
			this.Secret = secret;
			return this;
		}

		public RefundRequest SetTransactionID(string transId)
		{
			this.TransactionID = transId;
			return this;
		}

		public RefundRequest SetAmount(decimal amount)
		{
			this.Amount = amount;
			return this;
		}

		public RefundRequest SetCurrency(Enums.Currency currency)
		{
			this.Currency = currency;
			return this;
		}

		public RefundRequest SetTest(bool test)
		{
			this.Test = test;
			return this;
		}

		#endregion

	}
}
