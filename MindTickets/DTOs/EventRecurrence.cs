using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class EventRecurrence: BaseDTO 
	{
		public int EventId { get; set; }

		public string MultipleTimes { get; set; }

		public int Occurrences { get; set; }

		List<DateTime> DateaAndTimes { get; set; }
	}
}
