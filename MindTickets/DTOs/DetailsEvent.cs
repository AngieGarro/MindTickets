using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class DetailsEvent
	{

		//Table Events
		public string EventName { get; set; }

		public string? Logo { get; set; }

		public string? Modality { get; set; }

		public string? Slogan { get; set; }
		public DateTime DateAndTime { get; set; }

		public string Time { get; set; }


		//TABLE ADDRESS
		public string? ExactAddress { get; set; }

		public string? Description { get; set; }

		public string? Restrictions { get; set; }

		public string? EventPhoneNumber { get; set; }
		public string? EventEmail { get; set; }
		public string? EventWebSite { get; set; }
		public string? EventCategory { get; set; }

		public string? OrganizerName { get; set; }

		//TABLE TICKETS TYPE
		public int? VIP { get; set; }
		public double? PriceTicketVIP { get; set; }

		public int? Regular { get; set; }
		public double? PriceTicketRegular { get; set; }

		public int? Special { get; set; }
		public double? PriceTicketSpecial { get; set; }

		public int? Free { get; set; }
		public double? PriceTicketFree { get; set; }


	}
}
