using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Models
{
	public class PaymentRequest : API.BaseComGateRequest
	{
		public bool Test { get; set; }
		public Enums.Lang Lang { get; set; }
		

		public BaseComGatePayment Payment { get; set; }
		public Payer Payer { get; set; }

		#region Someone prefer Fluent API settings


		public PaymentRequest SetMerchant(string merchant)
		{
			this.Merchant = merchant;
			return this;
		}

		public PaymentRequest SetPreauth(Nullable<bool> preauth = null)
		{
			this.Payment.Preauth = preauth;
			return this;
		}

		public PaymentRequest SetEmbedded(Nullable<bool> embedded = null)
		{
			this.Payment.Embedded = embedded;
			return this;
		}

		public PaymentRequest SetVerification(Nullable<bool> verification = null)
		{
			this.Payment.Verification = verification;
			return this;
		}


		public PaymentRequest SetInitRecurring(Nullable<bool> initRecurring = null)
		{
			this.Payment.InitRecurring = initRecurring;
			return this;
		}

		public PaymentRequest SetEnviroment(bool IsTest)
		{
			if (IsTest)
			{
				this.Test = true;
			}
			else
			{
				this.Test = false;
			}
			
			return this;
		}

		public PaymentRequest SetProductionEnviroment()
		{
			this.Test = false;
			return this;
		}

		public PaymentRequest SetSecret(string secret)
		{
			this.Secret = secret;
			return this;
		}

		#endregion
	}
}
