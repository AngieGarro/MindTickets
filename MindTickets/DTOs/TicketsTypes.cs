using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class TicketsTypes:BaseDTO
	{
		public int VIP { get; set; }
		public double PriceTicketVIP { get; set; }

		public int Regular { get; set;}
		public double PriceTicketRegular { get; set; }

		public int Special { get; set; }
		public double PriceTicketSpecial { get; set; }

		public int Free { get; set;}
		public double PriceTicketFree { get; set; }


	}
}
