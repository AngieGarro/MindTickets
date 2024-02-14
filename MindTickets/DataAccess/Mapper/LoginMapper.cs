using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
	public class LoginMapper
	{
		public SqlOperation getRetrieveByEmailStatement(string correo)
		{

			var SqlOperation = new SqlOperation();
			SqlOperation.ProcedureName = "RET_OBTENER_USER_PR";

			SqlOperation.AddVarcharParam("Email", correo);
			return SqlOperation;

		}

		public SqlOperation GetInicioSesionStatement(string correo, string clave)
		{
			var SqlOperation = new SqlOperation();
			SqlOperation.ProcedureName = "RET_LOGIN_PR";

			SqlOperation.AddVarcharParam("Email", correo);
			SqlOperation.AddVarcharParam("Password", clave);

			return SqlOperation;
		}
		#region "Construccion de objetos"

		public BaseDTO BuildObject(Dictionary<string, object> row)

		{
			//Basado en la composicion de la fila en la base de datos construimos el objeto en POO
			var UserDTO = new User
			{
				Id = (int)row["UserId"],
				FullName = (string)row["FullName"],
				LastName = (string)row["LastName"],
				Email = (string)row["Email"],
				Phone = (string)row["Phone"],
				Password = (string)row["Password"],
				IDPicture = (string)row["IDPicture"],
				IDImage = (string)row["IDImage"],
				UserType = (string)row["UserType"],
				Token = (string)row["CodeOTP"]

			};
			return UserDTO;

		}

		public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
		{
			var lstResults = new List<BaseDTO>();
			foreach (var item in lstRows)
			{
				var personaDTO = BuildObject(item);
				lstResults.Add(personaDTO);
			}

			return lstResults;

		}
		#endregion
	}
}

