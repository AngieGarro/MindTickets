using DataAccess.DAO;
using DataAccess.Mapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
	public class DetailsEventCrudFactory : CrudFactory
	{
		DetailsEventMapper mapper;
		public DetailsEventCrudFactory() : base()
		{
			mapper = new DetailsEventMapper();
			dao = SqlDAO.GetInstance();

		}
		public override void AddImages(BaseDTO dto)
		{
			throw new NotImplementedException();
		}

		public override void Create(BaseDTO dto)
		{
			throw new NotImplementedException();
		}

		public override void Create(BaseDTO dto, BaseDTO dto1)
		{
			throw new NotImplementedException();
		}

		public override void Delete(BaseDTO dto)
		{
			throw new NotImplementedException();
		}

		public override void DeleteID(int Id)
		{
			throw new NotImplementedException();
		}

		public override T Retrieve<T>()
		{
			throw new NotImplementedException();
		}

		public override T Retrieve<T>(BaseDTO dto)
		{
			throw new NotImplementedException();
		}

		public override List<T> RetrieveAll<T>()
		{
			var DetailsEvents = new List<T>();
			var sqlOperation = mapper.GetRetriveAllStatement();
			var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
			var dic = new Dictionary<string, object>();
			if (lstResult.Count > 0)
			{
				var objsPojo = mapper.BuildObjects(lstResult);
				foreach (var c in objsPojo)
				{
					DetailsEvents.Add((T)Convert.ChangeType(c, typeof(T)));
				}
			}

			return DetailsEvents;
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
			throw new NotImplementedException();
		}
	}
}
