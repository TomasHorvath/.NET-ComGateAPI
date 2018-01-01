using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Enums
{
	public enum ErrorCode : int
	{
		OK = 0,
		//neznámá chyba
		UnknowError = 1100,
		//zadaný jazyk není podporován
		NotSupportedLanguage = 1102,
		// nesprávně zadaná metoda
		WrongPaymentMethod = 1103,
		//nelze načíst platbu
		CanNotLoadPayment = 1104,
		//databázová chyba
		DatabaseError = 1200,
		//neznámý eshop
		UnknowEshop = 1301,
		//propojení nebo jazyk chybí
		MissingLangOrConnection =1303, 
		//neplatná kategorie
		InvalidCategory = 1304 ,
		//chybí popis produktu
		ProductDesciptionMissing = 1305,
		//vyberte správnou metodu
		ChooseValidMethod = 1306, 
		//vybraný způsob platby není povolen
		SelectedPaymentMethodNowAllowed = 1308,
		//nesprávná částka
		WrongAmount = 1309,
		// naznámá měna
		UnknowCurrency = 1310, 
		// neplatný identifikátor bankovního účtu Klienta
		NonValidPayerAccountId = 1311,
		//eshop nemá povolené opakované platby
		EshopNotSupportRecurringPayments = 1316,
		// neplatná metoda – nepodporuje opakované platby
		PaymentMethodNotSupportRecurringPayments = 1317,
		// nelze založit platbu, problém na straně banky
		CanNotCreatePaymentBankServerError = 1319,
		//neočekávaný výsledek z databáze
		UnexpectedDatabaseResult = 1399 ,
		//chybný dotaz
		WrongQuery = 1400,  
		//neočekávaná chyba
		UnexpectedError = 1500
	}
}
