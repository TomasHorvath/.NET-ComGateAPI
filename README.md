# .NET-ComGateAPI - beta
Neoficiální .NET connector pro ComGate.cz platební bránu. V současné chvíli se jedná o beta verzi, která je ozkoušená oproti testovacímů prostředí ComGate.cz. Před vydáním bych chtěl provést refactoring některých metod.



## Podporované metody

1. Založení platby
2. Získání dostupných platebních metod
3. Získání stavu platby 
4. Potvrzení předautorizace platby
5. Zrušení předautorizace platby
6. Refundace platby

## Zatím nepodporované metody

1. Opakovaná platba - bude implementováno


### Použití

1. Příklad založení platby

```csharp
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
```

2.Příklad získání všech dostupných platebních metod

```csharp
// create ComGate connector 
IComGateApi comGateAPI = ComGateApiConnector.CreateConnector()
		.TestEnviroment()
		.SetLang()
		.SetMerchant(WebConfigurationManager.AppSettings["merchantId"])
		.SetSecret(WebConfigurationManager.AppSettings["secret"]);

// get available payment methods
var apiResponse = await comGateAPI.GetAvailebleMethods(WebConfigurationManager.AppSettings["api"]);

```


více informací naleznete [zde](http://thsoftware.cz/net-comgate-api/)