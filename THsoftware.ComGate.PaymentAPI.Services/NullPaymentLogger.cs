using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THsoftware.ComGate.Core.Domain.Models;
using THsoftware.ComGate.PaymentAPI.Interfaces;

namespace THsoftware.ComGate.PaymentAPI.Services
{
	public class NullPaymentLogger : IPaymentLogger
	{
		public void LogPayment(PaymentRequest request)
		{
			
		}
	}
}
