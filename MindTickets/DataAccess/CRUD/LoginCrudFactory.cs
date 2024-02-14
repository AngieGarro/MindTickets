using DataAccess.DAO;
using DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
	public class LoginCrudFactory
	{
		private LoginMapper _mapper;
		private SqlDAO _dao;

		public LoginCrudFactory()
		{
			_dao = SqlDAO.GetInstance();
			_mapper = new LoginMapper();
		}

		public T RetrieveByEmail<T>(string correo)
		{
			var user = default(T);

			var sqlOperation = _mapper.getRetrieveByEmailStatement(correo);
			var result = _dao.ExecuteQueryProcedure(sqlOperation);

			if (result.Count > 0)
			{
				var obj = _mapper.BuildObject(result[0]);
				user = (T)Convert.ChangeType(obj, typeof(T));
			}

			return user;
		}

		public List<Dictionary<string, object>> InicioSesion(string Email, string Password)
		{
			var sqlOperation = _mapper.GetInicioSesionStatement(Email, Password);

			return _dao.ExecuteQueryProcedure(sqlOperation);

		}
	}
}

