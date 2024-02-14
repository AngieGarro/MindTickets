using Core.RESTManagers;
using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
	public class UserManager
	{
		public UserManager() { }

		//REGISTRAR USUARIO CON CREACION DE EMAIL:
		public void CreateUser(User user)
		{
			//Genera OTP y Envia Email - SMS
			var response = new EmailManager();
			response.SendEmailAuth(user);
			response.SendSMS(user);

			//CREA EL USUARIO
			var crud = new UserCrudFactory();
			crud.Create(user);
		}

		//REGISTRAR NUEVO ADMINISTRADOR:
		public void CreateUserAdmi(User user)
		{
			//CREA EL USUARIO
			var crud = new UserCrudFactory();
			crud.CreateUserAdmi(user);
			//ENVIA LOS DATOS
			var response = new EmailManager();
			response.SendEmailAdmi(user);
			
		}

		public void Delete(User user)
		{
			var crud = new UserCrudFactory();
			crud.Delete(user);
		}

        public void DeleteById(int id)
        {
            var crud = new UserCrudFactory();
            crud.DeleteById(id);
        }


        public void Update(User user)
		{
			var crud = new UserCrudFactory();
			crud.Update(user);
		}

		public List<User> RetrieveAll()
		{
			var crud = new UserCrudFactory();
			return crud.RetrieveAll<User>();
		}

		public User RetrieveById(User user)
		{
            var crud = new UserCrudFactory();
            return crud.Retrieve<User>();
        }

		public string generateOtp()
		{
			Random rand = new Random();
			return rand.Next(100000, 999999).ToString();
		}
	}
}