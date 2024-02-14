using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Mapper
{
	public class UserMapper : ISqlStatements, IObjectMapper
	{
		public BaseDTO BuildObject(Dictionary<string, object> row)
		{
			var userDTO = new User
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

			return userDTO;
		}

		public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
		{
			var lstResults = new List<BaseDTO>();
			foreach (var item in lstRows)
			{
				var userDTO = BuildObject(item);
				lstResults.Add(userDTO);
			}
			return lstResults;
		}

		/* Delete*/
		public SqlOperation DeleteStatements(BaseDTO Dto)
		{
			var operation = new SqlOperation { ProcedureName = "DEL_USER_PR" };
			var user = (User)Dto;
			operation.AddIntParam("Id", user.Id);
			return operation;

		}
		/* Add*/
		public SqlOperation GetCreateStatements(BaseDTO Dto)
		{
			var SqlOperations = new SqlOperation();
			SqlOperations.ProcedureName = "CRE_USER_PR";

			var user = (User)Dto;
			SqlOperations.AddVarcharParam("User_Id", user.Id.ToString());
			SqlOperations.AddVarcharParam("FullName", user.FullName);
			SqlOperations.AddVarcharParam("LastName", user.LastName);
			SqlOperations.AddVarcharParam("Email", user.Email);
			SqlOperations.AddVarcharParam("Phone", user.Phone);
			SqlOperations.AddVarcharParam("Password", user.Password);
			SqlOperations.AddVarcharParam("IDPicture", user.IDPicture);
			SqlOperations.AddVarcharParam("IDImage", user.IDImage);
			SqlOperations.AddVarcharParam("UserType", user.UserType);
			SqlOperations.AddVarcharParam("Token", user.Token);

			//Address: Relacion
			SqlOperations.AddVarcharParam("PROVINCE", user.Location.Province);
			SqlOperations.AddVarcharParam("CANTON", user.Location.Canton);
			SqlOperations.AddVarcharParam("DISTRICT", user.Location.District);
			SqlOperations.AddVarcharParam("EXACT_ADDRESS", user.Location.ExactAddress);
			return SqlOperations;

		}

        public SqlOperation GetCreateAdminStatements(BaseDTO Dto)
        {
            var SqlOperations = new SqlOperation();
            SqlOperations.ProcedureName = "CRE_ADMIN_USER_PR";

            var user = (User)Dto;
            SqlOperations.AddVarcharParam("USERID", user.Id.ToString());
            SqlOperations.AddVarcharParam("FULLNAME", user.FullName);
            SqlOperations.AddVarcharParam("LASTNAME", user.LastName);
            SqlOperations.AddVarcharParam("EMAIL", user.Email);            
            SqlOperations.AddVarcharParam("PASSWORD", user.Password);                        
            SqlOperations.AddVarcharParam("USERTYPE", user.UserType);            
            return SqlOperations;

        }

        public SqlOperation GetRetrieveByIdStatement(BaseDTO dto)
        {
            var sqlOperations = new SqlOperation();
            sqlOperations.ProcedureName = "RET_USER_BY_ID_PR";
            return sqlOperations;
        }

        public SqlOperation GetRetrieveByIdStatements(int Id)
		{
			var sqlOperations = new SqlOperation();
			sqlOperations.ProcedureName = "RET_USER_BY_ID_PR";

			return sqlOperations;
		}

		public SqlOperation GetRetriveAllStatement()
		{
			var sqlOperations = new SqlOperation();
			sqlOperations.ProcedureName = "RET_ALL_USER_PR";
			return sqlOperations;
		}

		public SqlOperation GetUpdateStatements(BaseDTO Dto)
		{
			var SqlOperations = new SqlOperation();
			SqlOperations.ProcedureName = "UPD_USER_PR";

			var user = (User)Dto;
            SqlOperations.AddVarcharParam("ID", user.Id.ToString());
            SqlOperations.AddVarcharParam("FULLNAME", user.FullName);
			SqlOperations.AddVarcharParam("LASTNAME", user.LastName);
			SqlOperations.AddVarcharParam("EMAIL", user.Email);
			SqlOperations.AddVarcharParam("PHONE", user.Phone);
			SqlOperations.AddVarcharParam("IDPICTURE", user.IDPicture);
			SqlOperations.AddVarcharParam("IDIMAGE", user.IDImage);
            SqlOperations.AddVarcharParam("USERTYPE", user.UserType);


            return SqlOperations;
		}

		public SqlOperation DeleteIDStatements(int Id)
		{
            var operation = new SqlOperation { ProcedureName = "DEL_USER_PR" };
            operation.AddIntParam("Id", Id);
            return operation;
        }

        public SqlOperation DeleteStatements(int Id)
        {
            throw new NotImplementedException();
        }
    }
}