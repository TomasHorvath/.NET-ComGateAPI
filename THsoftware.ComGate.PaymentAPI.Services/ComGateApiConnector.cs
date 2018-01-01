using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using THsoftware.ComGate.Core.Domain.Enums;
using THsoftware.ComGate.Core.Domain.Models;
using THsoftware.ComGate.PaymentAPI.Interfaces;
using THsoftware.ComGate.PaymentAPI.Interfaces.API;
using THsoftware.ComGate.PaymentAPI.Interfaces.Factories;

namespace THsoftware.ComGate.PaymentAPI.Services
{
	/// <summary>
	/// 
	/// </summary>
	public class ComGateApiConnector : IComGateApi
	{
		#region fields 

		private readonly IComGateContentSerializer _serializer;
		private readonly IPaymentLogger _paymentLogger;
		private readonly IComGateRequestBuilder _requestBuilder;

		public string Merchant { get; set; }
		public bool IsTestEnviroment { get; set; } = false;
		public Core.Domain.Enums.Lang Lang { get; set; }
		public bool PrepareOnly { get; set; }
		public string Secret { get; set; }
		public Nullable<bool> Preauth { get; set; }
		public Nullable<bool> InitRecurring { get; set; }
		public Nullable<bool> Verification { get; set; }
		public Nullable<bool> Embedded { get; set; }

		#endregion

		#region Ctors 

		public ComGateApiConnector()
		{
			_serializer = new ComGateContentSerializer();
			_paymentLogger = new NullPaymentLogger();
			_requestBuilder = new ComGateRequestBuilder();
		}

		public ComGateApiConnector(IComGateContentSerializer serializer, IPaymentLogger paymentLogger, IComGateRequestBuilder requestBuilder)
		{
			_serializer = serializer;
			_paymentLogger = paymentLogger;
			_requestBuilder = requestBuilder;
		}

		#endregion

		#region Fluent API

		public static ComGateApiConnector CreateConnector()
		{
			return new ComGateApiConnector();
		}

		public ComGateApiConnector SetMerchant(string merchant)
		{
			this.Merchant = merchant;
			return this;
		}
		public ComGateApiConnector TestEnviroment(bool IsTest = true)
		{
			this.IsTestEnviroment = IsTest;
			return this;
		}

		public ComGateApiConnector SetLang(Core.Domain.Enums.Lang lang = Core.Domain.Enums.Lang.cs)
		{
			this.Lang = lang;
			return this;
		}

		public ComGateApiConnector SetPrepareOnly(bool prepareOnly = true)
		{
			this.PrepareOnly = prepareOnly;
			return this;
		}

		public ComGateApiConnector SetSecret(string secret) { this.Secret = secret; return this; }
		public ComGateApiConnector SetPreauth(bool preauth) { this.Preauth = preauth; return this; }
		public ComGateApiConnector SetInitRecurring(bool initRecurring) { this.InitRecurring = initRecurring; return this; }
		public ComGateApiConnector SetVerification(bool verification) { this.Verification = verification; return this; }
		public ComGateApiConnector SetEmbedded(bool embedded) { this.Embedded = embedded; return this; }

		#endregion

		#region API methods

		public async Task<ApiResponse<PaymentResponse>> CreatePayment(BaseComGatePayment payment, Payer payer, string ComGateAPIEndpointUrl)
		{

			PaymentRequest paymentRequest = _requestBuilder
				.CreatePaymentRequest(payment, payer)
				.SetMerchant(this.Merchant)
				.SetEnviroment(this.IsTestEnviroment)
				.SetSecret(this.Secret);

			using (var httpClient = HttpClientFactory.CreateHttpClient(Core.Domain.Enums.ComGateHttpClient.HttpClient))
			{
				_paymentLogger.LogPayment(paymentRequest);
				var content = _serializer.Serialize<PaymentRequest>(paymentRequest);

				httpClient.BaseAddress = new Uri(ComGateAPIEndpointUrl);

				var response = await httpClient.PostAsync("create", content);

				if (response.IsSuccessStatusCode)
				{
					var responseContent = await response.Content.ReadAsStringAsync();
					return _serializer.Deserialize<PaymentResponse>(responseContent);
				}
				else
				{
					throw new Exception("Cannot create payment");
				}
			}
		}

		public async Task<ApiResponse<PaymentMethodsResponse>> GetAvailebleMethods(string ComGateAPIEndpointUrl)
		{
			using (var httpClient = HttpClientFactory.CreateHttpClient(Core.Domain.Enums.ComGateHttpClient.HttpClient))
			{

				PaymentMethodsRequest methodsRequest = _requestBuilder
					.CreatePaymentMethodsRequest()
					.SetMerchant(this.Merchant)
					.SetSecret(this.Secret);

				var content = _serializer.Serialize<PaymentMethodsRequest>(methodsRequest);

				httpClient.BaseAddress = new Uri(ComGateAPIEndpointUrl);

				var response = await httpClient.PostAsync("methods", content);

				if (response.IsSuccessStatusCode)
				{
					var responseContent = await response.Content.ReadAsStringAsync();
					return _serializer.Deserialize<PaymentMethodsResponse>(responseContent);
				}
				else
				{
					throw new Exception("Cannot create method list");
				}
			}
		}

		public async Task<ApiResponse<PaymentStatusResponse>> GetPaymentStatus(string transId, string ComGateAPIEndpointUrl)
		{
			using (var httpClient = HttpClientFactory.CreateHttpClient(Core.Domain.Enums.ComGateHttpClient.HttpClient))
			{

				PaymentStatusRequest statusRequest = new PaymentStatusRequest()
					.SetMerchant(this.Merchant)
					.SetSecret(this.Secret)
					.SetTransactionId(transId);


				var content = _serializer.Serialize<PaymentStatusRequest>(statusRequest);

				httpClient.BaseAddress = new Uri(ComGateAPIEndpointUrl);

				var response = await httpClient.PostAsync("status", content);

				if (response.IsSuccessStatusCode)
				{
					var responseContent = await response.Content.ReadAsStringAsync();
					return _serializer.Deserialize<PaymentStatusResponse>(responseContent);
				}
				else
				{
					throw new Exception("Cannot create method list");
				}
			}
		}

		public async Task<ApiResponse<bool>> RefundPayment(string transId, decimal price, Currency currency, bool test, string ComGateAPIEndpointUrl)
		{
			using (var httpClient = HttpClientFactory.CreateHttpClient(Core.Domain.Enums.ComGateHttpClient.HttpClient))
			{

				RefundRequest refundRequest = new RefundRequest()
					.SetMerchant(this.Merchant)
					.SetSecret(this.Secret)
					.SetCurrency(currency)
					.SetTransactionID(transId)
					.SetAmount(price)
					.SetTest(test)
					;

				var content = _serializer.Serialize<RefundRequest>(refundRequest);

				httpClient.BaseAddress = new Uri(ComGateAPIEndpointUrl);

				var response = await httpClient.PostAsync("refund", content);

				if (response.IsSuccessStatusCode)
				{
					var responseContent = await response.Content.ReadAsStringAsync();
					return _serializer.Deserialize<bool>(responseContent);
				}
				else
				{
					throw new Exception("Cannot create method list");
				}
			}
		}

		public async Task<ApiResponse<RecurrentPaymentResponse>> RecurrentPayment(BaseComGatePayment payment, Payer payer, string ComGateAPIEndpointUrl)
		{
			throw new NotImplementedException();
		}

		public async Task<ApiResponse<bool>> CapturePreauth(string transId, string ComGateAPIEndpointUrl)
		{
			using (var httpClient = HttpClientFactory.CreateHttpClient(Core.Domain.Enums.ComGateHttpClient.HttpClient))
			{

				CapturePreAuthRequest capturePreauthRequest = new CapturePreAuthRequest()
					.SetMerchant(this.Merchant)
					.SetSecret(this.Secret)
					.SetTransactionID(transId);

				var content = _serializer.Serialize<CapturePreAuthRequest>(capturePreauthRequest);

				httpClient.BaseAddress = new Uri(ComGateAPIEndpointUrl);

				var response = await httpClient.PostAsync("capturePreauth", content);

				if (response.IsSuccessStatusCode)
				{
					var responseContent = await response.Content.ReadAsStringAsync();
					return _serializer.Deserialize<bool>(responseContent);
				}
				else
				{
					throw new Exception("Cannot create method list");
				}
			}
		}

		public async Task<ApiResponse<bool>> CancelPreauth(string transId, string ComGateAPIEndpointUrl)
		{

			using (var httpClient = HttpClientFactory.CreateHttpClient(Core.Domain.Enums.ComGateHttpClient.HttpClient))
			{

				CancelPreAuthRequest cancelPreauthRequest = new CancelPreAuthRequest()
					.SetMerchant(this.Merchant)
					.SetSecret(this.Secret)
					.SetTransactionID(transId);

				var content = _serializer.Serialize<CancelPreAuthRequest>(cancelPreauthRequest);

				httpClient.BaseAddress = new Uri(ComGateAPIEndpointUrl);

				var response = await httpClient.PostAsync("cancelPreauth", content);

				if (response.IsSuccessStatusCode)
				{
					var responseContent = await response.Content.ReadAsStringAsync();
					return _serializer.Deserialize<bool>(responseContent);
				}
				else
				{
					throw new Exception("Cannot create method list");
				}
			}
		}
		#endregion
	}
}
