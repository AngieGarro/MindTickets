using DataAccess.DAO;
using DTOs;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess.Mapper
{
	public class EventsMapper:IObjectMapper,ISqlStatements
	{

        public int BuildObjectCount(List<Dictionary<string, object>> lstRows)
        {
            
            int objectCount = 0;
            foreach (Dictionary<string, object> row in lstRows)
            {
              
                objectCount++;
            }

            return objectCount;
        }



        public BaseDTO BuildObject(Dictionary<string, object> row)
		{
			var events = new Events()
			{
				//Faltan Atributos por agregar
				Id = (int)row["Id"],
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
				CreatorId = (int)row["OrganizerID"],
            };

			return events;
		}

		public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
		{
			var lstResults = new List<BaseDTO>();

			foreach (var row in lstRows)
			{
				var events = BuildObject(row);
				lstResults.Add(events);
			}

			return lstResults;
		}

		public SqlOperation DeleteStatements(BaseDTO Dto)
		{
			throw new NotImplementedException();
		}

		//Para el registro del evento
		public SqlOperation GetCreateStatements(BaseDTO Dto, BaseDTO Dto1)
		{
			throw new NotImplementedException();
		}

		public SqlOperation GetAddImagesStatements(BaseDTO Dto)
		{
			throw new NotImplementedException();
		}

		public SqlOperation GetRetrieveByIdStatements(int Id)
		{
			var operation = new SqlOperation { ProcedureName = "RET_BY_ID_EVENT_PR" };

			operation.AddIntParam("EVENT_ID", Id);
			return operation;
		}

        public SqlOperation GetRetrieveMyCountEvents(int Id)
        {
            var sqlOperations = new SqlOperation();
            sqlOperations.ProcedureName = "RET_MY_EVENTS_PR";
            sqlOperations.AddIntParam("Id", Id);
            return sqlOperations;
        }

        public SqlOperation GetRetrieveMyEvents(int Id)
        {
            var sqlOperations = new SqlOperation();
            sqlOperations.ProcedureName = "RET_MY_EVENTS_PR";
            sqlOperations.AddIntParam("Id", Id);
            return sqlOperations;
        }

        public SqlOperation GetRetriveMyEventStatement()
		{
			var operation = new SqlOperation { ProcedureName = "RET_ALL_MY_EVENT_PR" };
			return operation;
		}

        public SqlOperation GetRetriveEventCreated(BaseDTO dto)
        {
			var user = (User)dto;
            var operation = new SqlOperation { ProcedureName = "RET_CREATED_EVENTS_PR" };
			operation.AddVarcharParam("ORGANIZERNAME", user.FullName);
			return operation;
        }

        public SqlOperation GetUpdateStatements(BaseDTO Dto)
		{
			var operation = new SqlOperation()
			{
				ProcedureName = "UPD_EVENT_PR"
			};

			var events = (Events)Dto;

			operation.AddVarcharParam("EVENT_NAME", events.EventName);
			operation.AddVarcharParam("LOGO", events.Logo);
			operation.AddDateTimeParam("DATE_AND_TIME", events.DateAndTime);
			operation.AddVarcharParam("DESCRIPTION", events.Description);
			operation.AddVarcharParam("TIME", events.Time);
			operation.AddIntParam("Id", events.Id);

			return operation;
		}

		public SqlOperation DeleteStatements(int Id)
		{
			var operation = new SqlOperation { ProcedureName = "DEL_EVENT_PR" };

			operation.AddIntParam("ID", Id);

			return operation;
		}

		//-------------------------------REGISTRO EVENTO---------------------------------
		public SqlOperation GetCreateStatements(BaseDTO Dto)
		{
			var operation = new SqlOperation()
			{
				ProcedureName = "CRE_EVENT_PR"
			};

			var events = (Events)Dto;
			operation.AddVarcharParam("EVENT_NAME", events.EventName);
			operation.AddVarcharParam("MODALITY", events.Modality);
			operation.AddVarcharParam("LOGO", events.Logo);
			operation.AddVarcharParam("SLOGAN", events.Slogan);
			operation.AddVarcharParam("DESCRIPTION", events.Description);
			operation.AddVarcharParam("RESTRICTIONS", events.Restrictions);
			operation.AddDateTimeParam("DATE_TIME", events.DateAndTime);
			operation.AddVarcharParam("EVENT_TIME", events.Time);
			// Event Manager
			operation.AddVarcharParam("ORGANIZER_NAME", events.OrganizerName);
			operation.AddIntParam("CREATOR_ID", events.CreatorId);

			// Address: Relacion
			operation.AddVarcharParam("PROVINCE", events.Location.Province);
			operation.AddVarcharParam("CANTON", events.Location.Canton);
			operation.AddVarcharParam("DISTRICT", events.Location.District);
			operation.AddVarcharParam("EXACT_ADDRESS", events.Location.ExactAddress);
			// Contact: Contacto
			operation.AddVarcharParam("PHONE_NUMBER", events.EventPhoneNumber);
			operation.AddVarcharParam("EMAIL", events.EventEmail);
			operation.AddVarcharParam("WEB_SITE", events.EventWebSite);
			operation.AddVarcharParam("CATEGORY", events.EventCategory);
			// Tickets Types:
			operation.AddIntParam("TYPES_VIP", events.TicketType.VIP);
			operation.AddDoubleParam("VIP_PRICE", events.TicketType.PriceTicketVIP);
			operation.AddIntParam("TYPES_SPECIAL", events.TicketType.Special);
			operation.AddDoubleParam("SPECIAL_PRICE", events.TicketType.PriceTicketSpecial);
			operation.AddIntParam("TYPES_REGULAR", events.TicketType.Regular);
			operation.AddFloatParam("REGULAR_PRICE", events.TicketType.PriceTicketRegular);
			operation.AddIntParam("TYPES_FREE", events.TicketType.Free);
			operation.AddDoubleParam("FREE_PRICE", events.TicketType.PriceTicketFree);

			return operation;
		}

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_EVENTS_PR" };
            return operation;
        }






        /*
        public SqlOperation GetRetrieveEventsCreated(int id)
        {
            var operation = new SqlOperation { ProcedureName = "RET_BY_ID_EVENT_PR" };

            operation.AddIntParam("EVENT_ID", Id);
            return operation;
        }
		*/
    }
}
