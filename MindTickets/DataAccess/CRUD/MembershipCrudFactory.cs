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


    public class MembershipCrudFactory : CrudFactory
    {
        MembershipMapper _mapper;

        public MembershipCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new MembershipMapper();
        }

		public override void AddImages(BaseDTO dto)
		{
			throw new NotImplementedException();
		}

		/* POST Methods */
		public override void Create(BaseDTO dto)
        {
            var membership = (Membership)dto;
            var SqlOperations = _mapper.GetCreateStatements(membership);
            dao.ExecuteProcedure(SqlOperations);
        }

		public override void Create(BaseDTO dto, BaseDTO dto1)
		{
			throw new NotImplementedException();
		}

		/* DELETE Methods */
		public override void Delete(BaseDTO dto)
        {
            var membership = (Membership)dto;
            var SqlOperation = _mapper.DeleteStatements(membership);
            dao.ExecuteProcedure(SqlOperation);
        }

        public override void DeleteID(int Id)
        {
            var SqlOperation = _mapper.GetDeleteStatements(Id);
            dao.ExecuteProcedure(SqlOperation);
        }

        /* GET Methods */
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
            var lstMemberships = new List<T>();
            var SqlOperation = _mapper.GetRetriveAllStatement();
            var lstResults = dao.ExecuteQueryProcedure(SqlOperation);

            if (lstResults.Count > 0)
            {
                // Invocamos Mapper para construir lista de objetos
                var objs = _mapper.BuildObjects(lstResults);

                foreach (var obj in objs)
                {
                    lstMemberships.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }
            return lstMemberships;
        }

        public override T RetrieveById<T>(int Id)
        {
            var lstResult = dao.ExecuteQueryProcedure(_mapper.GetRetrieveByIdStatements(Id));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var obj = _mapper.BuildObject(dic);
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            return default(T);
        }

        /*
        public int RetrieveByUser(int Id)
        {
            var lstResult = dao.ExecuteQueryProcedure(_mapper.GetRetrieveByUser(Id));
            Dictionary<int, int> dataStore = new Dictionary<int, int>
            return lstResult;
        }
        */
        /* PUSH Methods */
        public override void Update(BaseDTO dto)
        {
            var membership = (Membership)dto;
            var SqlOperation = _mapper.GetUpdateStatements(membership);
            dao.ExecuteProcedure(SqlOperation);
        }


        public T RetrieveMyMembership<T>(int Id) 
        {
            var membAcq = default(T);
            var SqlOperation = _mapper.RetrieveMyMembership(Id);
            var result = dao.ExecuteQueryProcedure(SqlOperation);

            if (result.Count > 0)
            {
                var obj = _mapper.BuildObjectAcq(result[0]);
                membAcq = (T)Convert.ChangeType(obj, typeof(T));
            }

            return membAcq;

        }






    }
}