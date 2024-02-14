using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class Transaction:BaseDTO
	{
		public string? IdTransaction { get; set; }		
		public int MembID { get; set; }
		public int UserId { get; set; }
        public string UserEmail{ get; set; }

        public DateTime? DateTimeTransaction { get; set; }

		public float TotalAmount { get; set; }
        public float TaxApplied { get; set; }
        public float FinalAmount { get; set; }
		
		public string? Status { get; set; }

		public string? Provider { get; set; }

		public string? Merchant { get; set; }
	}
}
