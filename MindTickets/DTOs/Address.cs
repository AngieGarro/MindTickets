using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class Address : BaseDTO
	{
		public int Id { get; set; }
		public string Province { get; set; }
		public string Canton { get; set; }
		public string District { get; set; }
		public string ExactAddress { get; set; }
	}

}
