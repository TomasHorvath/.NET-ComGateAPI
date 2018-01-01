using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Models.API
{
	public class BaseComGateRequest
	{
		public string Merchant { get; set; }
		public string Secret { get; set; }
		public string TransactionID { get; set; }

		#region Someone prefer Fluent API settings

		public virtual BaseComGateRequest SetMerchant(string merchant)
		{
			this.Merchant = merchant;
			return this;
		}

		public virtual BaseComGateRequest SetTransactionID(string transId)
		{
			this.TransactionID = transId;
			return this;
		}

		public virtual BaseComGateRequest SetSecret(string secret)
		{
			this.Secret = secret;
			return this;
		}

		#endregion
	}



}
