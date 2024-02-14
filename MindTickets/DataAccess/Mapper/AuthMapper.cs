using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DataAccess.Mapper
{
	public class AuthMapper : IObjectMapper
	{
		public BaseDTO BuildObject(Dictionary<string, object> row)
		{
			var user = new User
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

			return user;
		}

		public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
		{
			var lstResults = new List<BaseDTO>();

			foreach (var row in lstRows)
			{
				var user = BuildObject(row);
				lstResults.Add(user);
			}

			return lstResults;
		}
		
		//RESTABLECER CLAVE:
		public SqlOperation GetUpdateStatements(string pwrd, string email)
		{
			var SqlOperations = new SqlOperation();
			SqlOperations.ProcedureName = "UPD_USERRESETPASSWORD_PR";

			SqlOperations.AddVarcharParam("EMAIL", email);
			SqlOperations.AddVarcharParam("PASSWORD", pwrd);

			return SqlOperations;
		}

		//Confirmar OTP:
		public SqlOperation Confirmar(string userToken)
		{
				var SqlOperations = new SqlOperation();
				SqlOperations.ProcedureName = "AUTHETICATED_USER_PR";

				SqlOperations.AddVarcharParam("Token", userToken);


			return SqlOperations;
		}


		public SqlOperation GetConfirmarOTP(string userToken)
		{
			var SqlOperation = new SqlOperation();
			SqlOperation.ProcedureName = "RET_OTP_PR";

			SqlOperation.AddVarcharParam("Token", userToken);

			return SqlOperation;
		}
    }
}
	

