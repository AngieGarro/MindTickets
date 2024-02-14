using Core.RESTManagers;
using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
	public class AuthManager
	{
		private AuthCrudFactory crudUser;
		public AuthManager()
		{
			crudUser = new AuthCrudFactory();
		}

		//UPDATE PARA REALIZAR EL CAMBIO DE CONTRASEÑA EN CASO DE OLVIDARLA.
		public void ProcessPswrd(string pwrd, string email)
		{
			var crudFactory = new AuthCrudFactory();
			crudFactory.UpdatePassword(pwrd, email);
		}

        public void PasswordReset(string pwrd, string email)
        {
            var crudFactory = new AuthCrudFactory();
            crudFactory.UpdatePassword(pwrd, email);
        }

        //VALIDAR CUENTA:
        public void ValidateToken(string UserToken)
		{
			var crudFactory = new AuthCrudFactory();
			crudFactory.AuthToken(UserToken);
		}

		public List<Dictionary<string, object>> GetOTP(string token)
		{
			var crud = new AuthCrudFactory();
			return crud.GetOTP(token);
		}

		//EN CASO DE REQUERIR GENERAR UNA CLAVE TEMPORAL:
		public string generatePwrd()
		{
			var ran = new Random();
			var code = "";
			var chars = "@+-*!¡?¿ABCDEFGHIJKLMNOPQRSUVWXYZabcdefghijklmnopqrsuvwxyz" + "0123456789";

			for (int i = 0; i < 12; i++)
			{
				code += chars[ran.Next(chars.Length)];
			}
			return code;
		}

		//GENERAR TOKEN UNICO:
		public static string GenerarToken()
		{
			string token = Guid.NewGuid().ToString("N");
			return token;
		}

		//GENERATE RESTART PASSWORD:
		public void GeneratePswrd(string email)
		{
			var response = new EmailManager();
			response.SendEmailPasswrd(email);
		}
	}
}

