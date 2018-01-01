using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THsoftware.ComGate.Core.Domain.Models
{
	public class Payer
	{
		public string PayerId { get; set; }
		public Contact Contact { get; set; }
	}
}
