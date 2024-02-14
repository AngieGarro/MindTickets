using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
	public class LoginManager
	{
		public User retrieveByEmail(string correo)
		{
			var crud = new LoginCrudFactory();
			return crud.RetrieveByEmail<User>(correo);
		}


		public List<Dictionary<string, object>> InicioSesion(string correo, string clave)
		{
			var crud = new LoginCrudFactory();
			return crud.InicioSesion(correo, clave);
		}
	}
}

