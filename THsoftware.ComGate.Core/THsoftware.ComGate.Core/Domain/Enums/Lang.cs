using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Enums
{
	/// <summary>
	/// kód jazyka(ISO 639-1), ve kterém budou Plátci zobrazeny instrukce pro dokončení platby, povolené hodnoty(„cs”, „sk“, „en”), pokud parametr chybí, použije se „cs“
	/// </summary>
	public enum Lang
	{
		cs,
		sk,
		en
	}
}
