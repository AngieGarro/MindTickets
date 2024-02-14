using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class Purchase: BaseDTO
	{
		public int IdPurchase { get; set; }
		public int IdTransaction { get; set; }
		public int IdUser { get; set; }

	}
}
