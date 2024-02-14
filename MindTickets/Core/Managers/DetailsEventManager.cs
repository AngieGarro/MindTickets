using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
	public class DetailsEventManager
	{
		public List<DetailsEvent> RetrieveAll()
		{
			var crud = new DetailsEventCrudFactory();
			return crud.RetrieveAll<DetailsEvent>();
		}
		public DetailsEvent RetrieveById(int Id)
		{
			var crud = new DetailsEventCrudFactory();
			return crud.RetrieveById<DetailsEvent>(Id);
		}
	}
}
