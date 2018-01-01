namespace THsoftware.ComGate.WebClient.Models
{
	public class PaymentViewModel
	{
		public string TransId { get; set; }
		public string RefId { get; set; }
		public string Amount { get; set; }
		public Core.Domain.Enums.PaymentState State { get; set; }
	}
}