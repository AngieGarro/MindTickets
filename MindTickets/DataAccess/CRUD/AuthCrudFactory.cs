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
	public class AuthCrudFactory : CrudFactory
	{
		AuthMapper mapper;

		public AuthCrudFactory() : base()
		{
			mapper = new AuthMapper();
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
			throw new NotImplementedException();
		}

		public override T RetrieveById<T>(int Id)
		{
			throw new NotImplementedException();
		}

		public override void Update(BaseDTO dto)
		{
			throw new NotImplementedException();
		}


		//RESTABLECER CLAVE:
		public void UpdatePassword(string pwrd, string email)
		{
			var SqlOperations = mapper.GetUpdateStatements(pwrd,email);
			dao.ExecuteProcedure(SqlOperations);
		}

		//VALIDATE TOKEN:
		public void AuthToken(string userToken)
		{
			var SqlOperations = mapper.Confirmar(userToken);
			dao.ExecuteProcedure(SqlOperations);
		}

		public List<Dictionary<string, object>> GetOTP(string token)
		{
			var sqlOperation = mapper.GetConfirmarOTP(token);

			return dao.ExecuteQueryProcedure(sqlOperation);

		}
	}
}
