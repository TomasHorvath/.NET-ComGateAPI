using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THsoftware.ComGate.Core.Domain.Models;

namespace THsoftware.ComGate.PaymentAPI.Interfaces
{
	public interface IPaymentLogger
	{
		void LogPayment(PaymentRequest request);
	}
}
