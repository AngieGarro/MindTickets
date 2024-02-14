using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class Section : BaseDTO
	{
		public int IdSection { get; set; }

		public Stage Stage { get; set; }
		public string SectionName { get; set; }
	}
}
