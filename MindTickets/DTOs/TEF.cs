using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class TEF
	{
		public string Uban { get; set; } 
		public double Amount { get; set; }

		public string Description { get; set; }

		public string Sender { get; set; }
		
		public string TransactionId { get; set; }

		public string Status { get; set; }

		public DateTime TransactionDate { get; set; }
	}
}
