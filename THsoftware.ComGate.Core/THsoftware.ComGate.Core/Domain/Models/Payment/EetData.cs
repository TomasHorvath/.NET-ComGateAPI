using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Models
{
	public class EetData
	{
		//Celková částka tržby
		public long celk_trzba { get; set; }
		//Celková částka plnění osvobozených od DPH, ostatních plnění
		public long zakl_nepodl_dph { get; set; }
		//Celkový základ daně se základní sazbou DPH
		public long zakl_dan1 { get; set; }
		//Celková DPH se základní sazbou
		public long dan1 { get; set; }
		//Celkový základ daně s první sníženou sazbou DPH
		public long zakl_dan2 { get; set; }
		//Celková DPH s první sníženou sazbou
		public long dan2 { get; set; }
		//Celkový základ daně s druhou sníženou sazbou DPH	
		public long zakl_dan3 { get; set; }
		//Celková DPH s druhou sníženou sazbou
		public long dan3 { get; set; }
		// Celková částka v režimu DPH pro cestovní službu
		public long cest_sluz { get; set; }
		// Celková částka v režimu DPH pro prodej použitého zboží se základní sazbou
		public long pouzit_zboz1 { get; set; }
		//Celková částka v režimu DPH pro prodej použitého zboží s první sníženou sazbou
		public long pouzit_zboz2 { get; set; }
		//Celková částka v režimu DPH pro prodej použitého zboží s druhou sníženou
		public long pouzit_zboz3 { get; set; }
		//Celková částka plateb určená k následnému čerpání nebo zúčtování
		public long urceno_cerp_zuct { get; set; }
		//Celková částka plateb, které jsou následným čerpáním nebo zúčtováním
		public long cerp_zuct { get; set; }
	}
}
