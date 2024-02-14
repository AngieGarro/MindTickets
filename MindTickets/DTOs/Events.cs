using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class Events: BaseDTO
	{
		public int Id { get; set; }
		public string EventName { get; set; }

		public string? Modality { get; set; }

		public string? Logo { get; set; }

		public string? Slogan { get; set; }
		public DateTime DateAndTime { get; set; }

		public string Time { get; set; }	
		public Address? Location { get; set; }

		public string? Description { get; set; }

		public string? Restrictions { get; set; }

        public TicketsTypes? TicketType { get; set; }

		public string? OrganizerName { get; set; }

		public int CreatorId { get; set; }

		public string? EventPhoneNumber { get; set; }
		public string? EventEmail { get; set; }
		public string? EventWebSite { get; set; }
		public string? EventCategory { get; set; }

	}
}
