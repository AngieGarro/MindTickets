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
    public class TaxCrudFactory : CrudFactory
    {
        TaxMapper _mapper;

        public TaxCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new TaxMapper();
        }

		public override void AddImages(BaseDTO dto)
		{
			throw new NotImplementedException();
		}

		public override void Create(BaseDTO dto)
        {
            var tax = (Tax)dto;
            var SqlOperations = _mapper.GetCreateStatements(tax);
            dao.ExecuteProcedure(SqlOperations);
        }

		public override void Create(BaseDTO dto, BaseDTO dto1)
		{
			throw new NotImplementedException();
		}

		public override void Delete(BaseDTO dto)
        {
            var tax = (Tax)dto;
            var SqlOperation = _mapper.DeleteStatements(tax);
            dao.ExecuteProcedure(SqlOperation);
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

        public T RetrieveIVId<T>(int Id)
        {
            var tax = default(T);
            var SqlOperation = _mapper.GetRetrieveByIdStatements(Id);
            var result = dao.ExecuteQueryProcedure(SqlOperation);

            if (result.Count > 0)
            {
                var obj = _mapper.BuildObject(result[0]);
                tax = (T)Convert.ChangeType(obj, typeof(T));
            }

            return tax;

        }

        public override T RetrieveById<T>(int Id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO dto)
        {
            {
                var tax = (Tax)dto;
                var SqlOperation = _mapper.GetUpdateStatements(tax);
                dao.ExecuteProcedure(SqlOperation);
            }
        }

        
    }
}
