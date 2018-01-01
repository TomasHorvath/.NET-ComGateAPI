using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Models
{
	/// <summary>
	/// TODO create base class
	/// </summary>
	public class PaymentMethodsRequest : API.BaseComGateRequest
	{
		public Enums.DataType DataType { get; set; }
		public Enums.Currency Currency { get; set; }
		public Enums.Lang Lang { get; set; }


		#region Fluent API settings

		public PaymentMethodsRequest SetMerchant(string merchant)
		{
			this.Merchant = merchant;
			return this;
		}

		public PaymentMethodsRequest SetTransactionID(string transId)
		{
			this.TransactionID = transId;
			return this;
		}

		public PaymentMethodsRequest SetSecret(string secret)
		{
			this.Secret = secret;
			return this;
		}
		#endregion

	}
}
