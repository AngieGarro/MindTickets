using DataAccess.DAO;
using DataAccess.Mapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    /* Clase que Implementa el CRUD de Eventos */
    public class EventsCrudFactory : CrudFactory
    {
        EventsMapper mapper;
        public EventsCrudFactory() : base()
        {
            mapper = new EventsMapper();
            dao = SqlDAO.GetInstance();

        }

        public override void Create(BaseDTO dto, BaseDTO dto1)
        {
			throw new NotImplementedException();
		}

		public override void AddImages(BaseDTO dto)
		{
			throw new NotImplementedException();
		}

		public override void Delete(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

		public override void DeleteID(int Id)
		{
			var sqlOperation = mapper.DeleteStatements(Id);

			dao.ExecuteProcedure(sqlOperation);
		}

		//No implementado
		public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var listEvents = new List<T>();
            var sqlOperation = mapper.GetRetriveMyEventStatement();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveMyEventStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objsPojo = mapper.BuildObjects(lstResult);
                foreach (var c in objsPojo)
                {
                    listEvents.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listEvents;
        }
        public override T RetrieveById<T>(int Id)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveByIdStatements(Id));

            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objsPojo = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objsPojo, typeof(T));
            }

            return default(T);
        }

        public override void Update(BaseDTO dto)
        {
			var events = (Events)dto;

			var sqlOperation = mapper.GetUpdateStatements(events);

			dao.ExecuteProcedure(sqlOperation);
		}

        //REGISTRO EVENTO:
		public override void Create(BaseDTO dto)
		{
			var events = (Events)dto;

			var sqlOperation = mapper.GetCreateStatements(events);

			dao.ExecuteProcedure(sqlOperation);
		}
		
        public override T Retrieve<T>(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public List<T> RetrieveMyEvents<T>(int Id)
        {
            var listEvents = new List<T>();
            var sqlOperation = mapper.GetRetrieveMyEvents(Id);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var obj in objs)
                {
                    listEvents.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }

            return listEvents;
        }

        public int RetrieveMyEventsAndReturnCount(int id)
        {

            var countEvents = 0;
            var sqlOperation = mapper.GetRetrieveMyCountEvents(id);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            countEvents = mapper.BuildObjectCount(lstResult);

            return countEvents;
            
        }


        /*
        public T RetrieveMyEvents<T>(int Id)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveMyEvents(Id));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var obj = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            return default(T);
        }*/
    }
}
