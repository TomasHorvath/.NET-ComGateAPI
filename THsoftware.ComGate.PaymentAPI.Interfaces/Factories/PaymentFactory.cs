using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THsoftware.ComGate.Core.Domain.Models;

namespace THsoftware.ComGate.PaymentAPI.Interfaces.Factories
{
	public class PaymentFactory
	{
		public static BaseComGatePayment GetBasePayment(int price, string referenceId, string label, Core.Domain.Enums.PaymentMethods method = Core.Domain.Enums.PaymentMethods.ALL, EetData eet = null )
		{
			return new BaseComGatePayment()
			{
				Country = Core.Domain.Enums.Country.CZ,
				Currency = Core.Domain.Enums.Currency.CZK,
				PaymentCategory = Core.Domain.Enums.PaymentCategory.PHYSICAL,
				Price = price,
				ReferenceId = referenceId,
				Method = method,
				Label = label,
				EET = eet
			};
		}
	}
}
