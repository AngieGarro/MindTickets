using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class Ticket:BaseDTO
	{

		//TABLE TICKETS TYPE
		public string TicketType { get; set; }

		public string TicketsTypePrice { get; set; }

		//TABLE TICKETS
		public int TicketId { get; set; }

		//TABLE USERS
		public string user { get; set; }

		public string EmailUser { get; set; }

		//TABLE EVENTS
		public string eventsName { get; set; }
		public DateTime eventsDate { get; set; }

		public string eventsTime { get; set; }

		//TABLE STAGE
		public string seatNumber { get; set; }
	}
}
