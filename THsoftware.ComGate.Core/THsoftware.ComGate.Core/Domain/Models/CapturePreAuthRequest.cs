using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THsoftware.ComGate.Core.Domain.Models.API;

namespace THsoftware.ComGate.Core.Domain.Models
{
	/// <summary>
	/// TODO create base class
	/// </summary>
	public class CapturePreAuthRequest : BaseComGateRequest
	{

		#region Fluent API settings

		public CapturePreAuthRequest SetMerchant(string merchant)
		{
			this.Merchant = merchant;
			return this;
		}

		public CapturePreAuthRequest SetTransactionID(string transId)
		{
			this.TransactionID = transId;
			return this;
		}

		public CapturePreAuthRequest SetSecret(string secret)
		{
			this.Secret = secret;
			return this;
		}
		#endregion

	}
}
