using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class Seat:BaseDTO
	{
		public int IdEvent {  get; set; }

		public int IdStage { get; set; }
        public string seatNumber { get; set; }

        public int sectorId { get; set; }
        public int active { get; set; }
        public int idClient { get; set; }
    }
}
