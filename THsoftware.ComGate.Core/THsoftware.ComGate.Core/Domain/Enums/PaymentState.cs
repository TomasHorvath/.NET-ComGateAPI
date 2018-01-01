using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Enums
{
	public enum PaymentState
	{
		//Platba byla založená, finální výsledek platby zatím není známý
		PENDING,
		//Plátce úspěšně zaplatil platbu – je možné vydat zboží resp. zpřístupnit službu.
		PAID,
		//Platba nebyla zaplacena, zboží nebude vydáno resp. služba nebude poskytnuta. Ve výjimečných případech se může stát, že tento stav bude změněn na stav PAID.
		CANCELLED,
		//Předautorizace platby proběhla úspěšně (peníze na kartě plátce byly zablokovány). Čeká se na další požadavek, kterým bude potvrzena nebo zrušena.
		AUTHORIZED
	}
}
