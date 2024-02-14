using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class Stage : BaseDTO
	{
		public string StageType { get; set; }
		public int Capacity { get; set; }
	}
}
