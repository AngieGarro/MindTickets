using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
	public class DetailsEventMapper : ISqlStatements 
	{
		public List<DetailsEvent> BuildObjects(List<Dictionary<string, object>> lstRows)
		{
			var lstResults = new List<DetailsEvent>();

			foreach (var row in lstRows)
			{
				var events = BuildObject(row);
				lstResults.Add(events);
			}

			return lstResults;
		}

		public DetailsEvent BuildObject(Dictionary<string, object> row)
		{
			var events = new DetailsEvent()
			{
				//Atributos por Evento
				EventName = (string)row["EventName"],
				Modality = (string)row["Modality"],
				Logo = (string)row["Logo"],
				Slogan = (string)row["Slogan"],
				DateAndTime = (DateTime)row["DateAndTime"],
				Time = (string)row["Time"],
				Description = (string)row["Description"],
				Restrictions = (string)row["Restrictions"],
				OrganizerName = (string)row["OrganizerName"],
				EventPhoneNumber = (string)row["EventPhoneNumber"],
				EventEmail = (string)row["EventEmail"],
				EventWebSite = (string)row["EventWebSite"],
				EventCategory = (string)row["EventCategory"],
				//Atributos por Address
				ExactAddress = (string)row["ExactAddress"],
				VIP = (int)row["VIP"],
				PriceTicketVIP = (double)row["PriceTicketVIP"],
				Regular = (int)row["VIP"],
				PriceTicketRegular = (double)row["PriceTicketRegular"],
				Special = (int)row["Special"],
				PriceTicketSpecial = (double)row["PriceTicketSpecial"],
				Free = (int)row["VIP"],
				PriceTicketFree = (double)row["PriceTicketFree"],

			};
			return events;
		}

		public SqlOperation GetCreateStatements(BaseDTO Dto)
		{
			throw new NotImplementedException();
		}

		public SqlOperation GetUpdateStatements(BaseDTO Dto)
		{
			throw new NotImplementedException();
		}

		public SqlOperation DeleteStatements(BaseDTO Dto)
		{
			throw new NotImplementedException();
		}

		public SqlOperation DeleteStatements(int Id)
		{
			throw new NotImplementedException();
		}

		public SqlOperation GetRetrieveByIdStatements(int Id)
		{
			var operation = new SqlOperation { ProcedureName = "ID_DETAIL_EVENT_PR" };

			operation.AddIntParam("ID", Id);

			return operation;
		}

		public SqlOperation GetRetriveAllStatement()
		{
			var operation = new SqlOperation { ProcedureName = "RET_ALL_DETAILS_EVENT_PR" };
			return operation;
		}
	}

}
	


