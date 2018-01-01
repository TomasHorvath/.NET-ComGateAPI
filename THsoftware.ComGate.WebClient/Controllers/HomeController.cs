using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using THsoftware.ComGate.Core.Domain.Models;
using THsoftware.ComGate.PaymentAPI.Interfaces.API;
using THsoftware.ComGate.PaymentAPI.Interfaces.Factories;
using THsoftware.ComGate.PaymentAPI.Services;
using THsoftware.ComGate.WebClient.Models;

namespace THsoftware.ComGate.WebClient.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}


		public async Task<ActionResult> Methods()
		{
			// create ComGate connector 
			IComGateApi comGateAPI = ComGateApiConnector.CreateConnector()
				.TestEnviroment()
				.SetLang()
				.SetMerchant(WebConfigurationManager.AppSettings["merchantId"])
				.SetSecret(WebConfigurationManager.AppSettings["secret"]);

			// get available payment methods
			var apiResponse = await comGateAPI.GetAvailebleMethods(WebConfigurationManager.AppSettings["api"]);

			return View(apiResponse);
		}

		public async Task<ActionResult> CreatePayment()
		{
			Models.BasicPaymentViewModel viewModel = new Models.BasicPaymentViewModel()
			{
				Email = "EmailPlatce@email.cz",
				Name = "Jméno zákazníka",
				Label = "Krátký popis platby",
				ReferenceId = Guid.NewGuid().ToString()
			};
			return View(viewModel);
		}

		[HttpPost]
		public async Task<ActionResult> CreatePayment(Models.BasicPaymentViewModel model)
		{
			// create ComGate connector 
			IComGateApi comGateAPI = ComGateApiConnector.CreateConnector()
				.TestEnviroment()
				.SetLang()
				.SetMerchant(WebConfigurationManager.AppSettings["merchantId"])
				.SetSecret(WebConfigurationManager.AppSettings["secret"]);

			var cents = (int)(model.Price * 100);

			BaseComGatePayment payment = PaymentFactory.GetBasePayment(cents, model.ReferenceId, model.Label, Core.Domain.Enums.PaymentMethods.ALL);

			Payer customer = new Payer();

			customer.Contact = new Contact()
			{
				Email = model.Email,
				Name = model.Name
			};

			var response = await comGateAPI.CreatePayment(payment, customer, WebConfigurationManager.AppSettings["api"]);


			return Redirect(response.Response.RedirectUrl);
		}


		public async Task<ActionResult> Payment()
		{

			Models.AdvancedPaymentViewModel viewModel = new Models.AdvancedPaymentViewModel()
			{
				Email = "EmailPlatce@email.cz",
				Name = "Jméno zákazníka",
				Label = "Krátký popis platby",
				ReferenceId = Guid.NewGuid().ToString(),
				Currencies = (Enum.GetValues(typeof(Core.Domain.Enums.Currency)).Cast<Core.Domain.Enums.Currency>().Select(
			   enu => new SelectListItem() { Text = enu.ToString(), Value = enu.ToString() })).ToList(),

				PaymentMethods = (Enum.GetValues(typeof(Core.Domain.Enums.PaymentMethods)).Cast<Core.Domain.Enums.PaymentMethods>().Select(
			   enu => new SelectListItem() { Text = enu.ToString(), Value = enu.ToString() })).ToList()

			};

			// test eet value
			viewModel.Price = 495;
			viewModel.EETData = "{\"celk_trzba\": \"49500\",\"zakl_nepodl_dph\": \"0\",\"zakl_dan1\": \"4132\",\"dan1\": \"868\",\"zakl_dan2\": \"10000\",\"dan2\": \"1500\",\"zakl_dan3\": \"0\",\"dan3\": \"0\",\"cest_sluz\": \"0\",\"pouzit_zboz1\": \"33000\",\"pouzit_zboz2\": \"0\",\"pouzit_zboz3\": \"0\",\"urceno_cerp_zuct\": \"0\",\"cerp_zuct\": \"0\"}";

			IComGateApi comGateAPI = ComGateApiConnector.CreateConnector()
			.TestEnviroment()
			.SetLang()
			.SetMerchant(WebConfigurationManager.AppSettings["merchantId"])
			.SetSecret(WebConfigurationManager.AppSettings["secret"]);

			var apiResponse = await comGateAPI.GetAvailebleMethods(WebConfigurationManager.AppSettings["api"]);

			if (apiResponse.Success)
			{
				viewModel.PaymentMethods = apiResponse.Response.methods.Select(e => new SelectListItem() { Value = e.name, Text = e.id }).ToList();
				viewModel.Methods = apiResponse.Response.methods;
			}

			return View(viewModel);
		}

		[HttpPost]
		public async Task<ActionResult> Payment(Models.AdvancedPaymentViewModel model)
		{
			// create ComGate connector 
			IComGateApi comGateAPI = ComGateApiConnector.CreateConnector()
				.TestEnviroment()
				.SetLang()
				.SetMerchant(WebConfigurationManager.AppSettings["merchantId"])
				.SetSecret(WebConfigurationManager.AppSettings["secret"]);

			var cents = (int)(model.Price * 100);

			BaseComGatePayment payment = PaymentFactory.GetBasePayment(cents, model.ReferenceId, model.Label, model.SelectedMethod);

			payment.Currency = model.SelectedCurrency;
			payment.Preauth = model.PreAuth;
			payment.PrepareOnly = true;
			payment.EET = JsonConvert.DeserializeObject<EetData>(model.EETData);
			payment.EetReport = true;

			Payer customer = new Payer();
			customer.Contact = new Contact() { Email = model.Email, Name = model.Name };

			var response = await comGateAPI.CreatePayment(payment, customer, WebConfigurationManager.AppSettings["api"]);


			return Redirect(response.Response.RedirectUrl);
		}


		public async Task<ActionResult> GetPaymentStatus(string transId)
		{

			// create ComGate connector 
			IComGateApi comGateAPI = ComGateApiConnector.CreateConnector()
				.TestEnviroment()
				.SetLang()
				.SetMerchant(WebConfigurationManager.AppSettings["merchantId"])
				.SetSecret(WebConfigurationManager.AppSettings["secret"]);

			var apiResponse = await comGateAPI.GetPaymentStatus(transId, WebConfigurationManager.AppSettings["api"]);


			return View(apiResponse);

		}

		public async Task<ActionResult> PaymentsList()
		{
			// get payments log 

			var directory = new DirectoryInfo(Server.MapPath("~/DRead/"));
			var files = directory.GetFiles("*.txt");
			List<PaymentViewModel> paymentList = new List<PaymentViewModel>();

			foreach (var file in files)
			{
				paymentList.Add(ParseFile(file));
			}

			return View(paymentList);

		}


		private PaymentViewModel ParseFile(FileInfo file)
		{

			List<KeyValuePair<string, string>> output = new List<KeyValuePair<string, string>>();

			var lines = System.IO.File.ReadLines(file.FullName);

			var transId = string.Empty;
			var refId = string.Empty;
			var amount = string.Empty;

			foreach (var line in lines)
			{
				var keyValue = line.Split(':');
				// secret nezobrazime
				if (keyValue[0] != "secret")
				{
					output.Add(new KeyValuePair<string, string>(keyValue[0], keyValue[1]));
				}
			}

			return new PaymentViewModel()
			{
				TransId = output.First(e => e.Key == "transId").Value,
				RefId = output.First(e => e.Key == "refId").Value,
				Amount = output.First(e => e.Key == "price").Value,
				State = (Core.Domain.Enums.PaymentState)Enum.Parse(typeof(Core.Domain.Enums.PaymentState), output.First(e => e.Key == "status").Value, true),
			};

		}

		public async Task<ActionResult> RefundPayment(string transId)
		{
			RefundPaymentViewModel model = new RefundPaymentViewModel();
			model.TransactionId = transId;
			model.Amount = 0;
			model.Currencies = (Enum.GetValues(typeof(Core.Domain.Enums.Currency)).Cast<Core.Domain.Enums.Currency>().Select(
			   enu => new SelectListItem() { Text = enu.ToString(), Value = enu.ToString() })).ToList();

			return View(model);

		}

		[HttpPost]
		public async Task<ActionResult> RefundPayment(Models.RefundPaymentViewModel refund)
		{
			// create ComGate connector 
			IComGateApi comGateAPI = ComGateApiConnector.CreateConnector()
				.TestEnviroment()
				.SetLang()
				.SetMerchant(WebConfigurationManager.AppSettings["merchantId"])
				.SetSecret(WebConfigurationManager.AppSettings["secret"]);

			var cents = (int)(refund.Amount * 100);

			var response = await comGateAPI.RefundPayment(refund.TransactionId, cents, refund.Currency, true, WebConfigurationManager.AppSettings["api"]);
			return View("RefundComplete", response);

		}


		public async Task<ActionResult> CancelPreAuth(string transId)
		{
			// create ComGate connector 
			IComGateApi comGateAPI = ComGateApiConnector.CreateConnector()
				.TestEnviroment()
				.SetLang()
				.SetMerchant(WebConfigurationManager.AppSettings["merchantId"])
				.SetSecret(WebConfigurationManager.AppSettings["secret"]);

			var response = await comGateAPI.CancelPreauth(transId, WebConfigurationManager.AppSettings["api"]);
			return View(response);
		}

		public async Task<ActionResult> CapturePreAuth(string transId)
		{
			// create ComGate connector 
			IComGateApi comGateAPI = ComGateApiConnector.CreateConnector()
				.TestEnviroment()
				.SetLang()
				.SetMerchant(WebConfigurationManager.AppSettings["merchantId"])
				.SetSecret(WebConfigurationManager.AppSettings["secret"]);

			var response = await comGateAPI.CapturePreauth(transId, WebConfigurationManager.AppSettings["api"]);
			return View(response);

		}


		[HttpPost]
		public ActionResult Status()
		{
			var path = Server.MapPath("~/DRead/" + Request.Form["refId"] + ".txt");

			// check if file exists
			if (System.IO.File.Exists(path))
			{
				System.IO.File.Delete(path);
			}

			using (System.IO.StreamWriter file =
			new System.IO.StreamWriter(path, true))
			{
				// Write data to FILE

				var items = Request.Form.AllKeys.SelectMany(Request.Form.GetValues, (k, v) => new { key = k, value = v });
				foreach (var item in items)
					file.WriteLine("{0}:{1}", item.key, item.value);

			}
			return Content("code=0&message=OK", "application/x-www-form-urlencoded; charset=utf-8");
		}


		public ActionResult PaymentCallback(string id, string refId)
		{

			List<KeyValuePair<string, string>> output = new List<KeyValuePair<string, string>>();

			var lines = System.IO.File.ReadLines(Server.MapPath("~/DRead/" + refId + ".txt"));
			foreach (var line in lines)
			{
				var keyValue = line.Split(':');

				// secret nezobrazime
				if (keyValue[0] != "secret")
				{
					output.Add(new KeyValuePair<string, string>(keyValue[0], keyValue[1]));
				}

			}

			return View(output);
		}
	}
}