using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THsoftware.ComGate.Core.Domain.Models;
using THsoftware.ComGate.PaymentAPI.Interfaces;

namespace THsoftware.ComGate.PaymentAPI.Services
{
	public class ComGateRequestBuilder : IComGateRequestBuilder
	{
		public PaymentRequest CreatePaymentRequest(
			BaseComGatePayment payment,
			Payer payer,
			Core.Domain.Enums.Lang lang = Core.Domain.Enums.Lang.cs
			)
		{
			PaymentRequest request = new PaymentRequest();
			request.Payment = payment;
			request.Payer = payer;
			request.Payment.Embedded = payment.Embedded;
			request.Payment.InitRecurring = payment.InitRecurring;
			request.Payment.Preauth = payment.Preauth;
			request.Payment.Verification = payment.Verification;
			request.Lang = lang;
			request.Payment.PrepareOnly = payment.PrepareOnly;
			return request;
		}


		public PaymentMethodsRequest CreatePaymentMethodsRequest()
		{
			PaymentMethodsRequest request = new PaymentMethodsRequest();
			request.DataType = Core.Domain.Enums.DataType.JSON;
			request.Currency = Core.Domain.Enums.Currency.CZK;
			request.Lang = Core.Domain.Enums.Lang.cs;
			
			return request;
		}

	}
}
