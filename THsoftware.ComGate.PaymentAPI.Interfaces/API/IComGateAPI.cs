using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THsoftware.ComGate.Core.Domain.Models;

namespace THsoftware.ComGate.PaymentAPI.Interfaces.API
{
	public interface IComGateApi
	{
		Task<ApiResponse<PaymentResponse>> CreatePayment(BaseComGatePayment payment, Payer payer, string ComGateAPIEndpointUrl);
		Task<ApiResponse<PaymentMethodsResponse>> GetAvailebleMethods(string ComGateAPIEndpointUrl);
	    Task<ApiResponse<PaymentStatusResponse>> GetPaymentStatus(string transId, string ComGateAPIEndpointUrl);
		Task<ApiResponse<bool>> RefundPayment(string transId, decimal price, ComGate.Core.Domain.Enums.Currency currency, bool test, string ComGateAPIEndpointUrl);
		Task<ApiResponse<RecurrentPaymentResponse>> RecurrentPayment(BaseComGatePayment payment, Payer payer, string ComGateAPIEndpointUrl);
		Task<ApiResponse<bool>> CapturePreauth(string transId, string ComGateAPIEndpointUrl);
		Task<ApiResponse<bool>> CancelPreauth(string transId, string ComGateAPIEndpointUrl);
	}
}
