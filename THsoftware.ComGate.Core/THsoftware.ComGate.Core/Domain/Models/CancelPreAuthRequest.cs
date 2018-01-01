using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THsoftware.ComGate.Core.Domain.Models.API;

namespace THsoftware.ComGate.Core.Domain.Models
{
	public class CancelPreAuthRequest : BaseComGateRequest
	{
		
		#region Fluent API settings

		public CancelPreAuthRequest SetMerchant(string merchant)
		{
			this.Merchant = merchant;
			return this;
		}

		public CancelPreAuthRequest SetTransactionID(string transId)
		{
			this.TransactionID = transId;
			return this;
		}

		public CancelPreAuthRequest SetSecret(string secret)
		{
			this.Secret = secret;
			return this;
		}

		#endregion

	}
}
