using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Enums
{
	public enum PaymentMethods
	{
		//Platební metodu si vybere Plátce v rozcestníku
		ALL,
		//Poskytovatel automaticky
		CARD_ALL,
		CARD_CZ_BS,

		//Banku Plátce vybere v rozcestníku ComGate Payments
		BANK_ALL,

		//Bankovní převod Air Bank
		BANK_CZ_AB,

		//Bankovní převod ČSOB
		BANK_CZ_CSOB,

		//Bankovní převod Equa Bank
		BANK_CZ_EB,

		//Bankovní převod jiných bank
		BANK_CZ_OTHER,

		//Bankovní tlačítko Raiffeisen Bank
		BANK_CZ_RB,

		//Bankovní tlačítko Komerční Banky
		BANK_CZ_KB,

		//Bankovní tlačítko GE Money Bank
		BANK_CZ_GE,

		//Bankovní tlačítko Sberbank CZ
		BANK_CZ_VB,

		//Bankovní tlačítko FIO Banky
		BANK_CZ_FB,

		//Bankovní tlačítko České spořitelny
		BANK_CZ_CS_P,

		//Bankovní tlačítko mBank
		BANK_CZ_MB_P,

		//Bankovní tlačítko ČSOB
		BANK_CZ_CSOB_P,

		//Bankovní tlačítko era
		BANK_CZ_PS_P,

		//Bankovní tlačítko UniCredit Bank
		BANK_CZ_UC,

		//Bankovní tlačítko Slovenské spořiteľňy
		BANK_SK_SP,

		//Bankovní tlačítko VÚB Banky
		BANK_SK_VUB,

		//Bankovní tlačítko Tatra Banky
		BANK_SK_TB,

		//Bankovní tlačítko ČSOB

		BANK_SK_CSOB,
		//Bankovní tlačítko UniCredit Bank

		BANK_SK_UC,

		//Bankovní tlačítko Poštovná Banka
		BANK_SK_PB,

		//Bankovní převod Prima Bank
		BANK_SK_DEXIA,

		//Bankovní převod Fio Banky
		BANK_SK_FB,

		//Bankovní převod jiných bank
		BANK_SK_OTHER
	}
}
