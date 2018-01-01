using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THsoftware.ComGate.Core.Domain.Enums;

namespace THsoftware.ComGate.Core.Domain.Models
{
	public class BaseComGatePayment
	{
		/// <summary>
		///Cena za produkt v centech nebo haléřích. Musí být min. 10 CZK(včetně), max.neomezeno.
		/// </summary>
		public decimal Price { get; set; }
		/// <summary>
		///Kód měny dle ISO 4217, standardně „CZK“
		/// </summary>
		public Currency Currency { get; set; }
		/// <summary>
		///kód země („CZ“, „SK“, „PL“, „ALL“), pokud parametr chybí, použije se „CZ“, parametr slouží k omezení výběru platebních metod na ComGate platební bráně
		/// </summary>
		public Country Country { get; set; }

		public PaymentCategory PaymentCategory { get; set; }
		/// <summary>
		///reference platby v systému Klienta (nemusí být unikátní, tzn., že lze založit více plateb se stejným refId)
		/// </summary>
		public string ReferenceId { get; set; }
		/// <summary>
		///krátký popis produktu(1-16 znaků)
		/// </summary>
		public string Label { get; set; }
		/// <summary>
		///metoda platby, z tabulky platebních metod, hodnota „ALL“ v případě, že si má metodu vybrat plátce, nebo jednoduchý výraz s výběrem metod (popsáno níže)
		/// </summary>
		public PaymentMethods Method { get; set; }
		/// <summary>
		///identifikátor bankovního účtu Klienta, na který ComGate Payments převede peníze. Pokud parametr nevyplníte, použije se výchozí účet Klienta. Seznam účtů Klienta najdete na https://portal.comgate.cz/
		/// </summary>
		public string Account { get; set; }
		/// <summary>
		/// Struktura s daty pro zaevidování platby do EET. Odpovídá parametrům ze specifikace protokolu EET. Pokud má eshop nastaveno odesílání tržby do EET a parametr nebude vyplněn, použije se výchozí nastavení z konfigurace v Klientském Portálu.
		/// </summary>
		public EetData EET { get; set; }
		/// <summary>
		/// Příznak odeslání dat do EET. Pokud je vyplněno, přetěžuje nastavení EET v konfiguraci obchodu v Klientském Portálu.
		/// </summary>
		public bool EetReport { get; set; }

		public Nullable<bool> Preauth { get; set; }
		public Nullable<bool> InitRecurring { get; set; }
		public Nullable<bool> Verification { get; set; }
		public Nullable<bool> Embedded { get; set; }
		public bool PrepareOnly { get; set; }

	}
}
