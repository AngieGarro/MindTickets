using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class MembershipMapper : ISqlStatements, IObjectMapper
    {
        #region "Interface ISqlStatements (Envio de data a la BD)"


        /* POST Methods */
        public SqlOperation GetCreateStatements(BaseDTO Dto)
        {
            var SqlOperations = new SqlOperation();
            SqlOperations.ProcedureName = "CRE_MEMBERSHIP_PR";

            var membership = (Membership)Dto;
            SqlOperations.AddVarcharParam("MEMBERSHIPNAME", membership.MembershipName);
            SqlOperations.AddVarcharParam("DESCRIPTION", membership.Description);
            SqlOperations.AddIntParam("TICKETLIMIT", membership.TicketLimit);
            SqlOperations.AddFloatParam("COMMISSION", membership.Commission);
            SqlOperations.AddIntParam("EVENTLIMIT", membership.EventLimit);
            SqlOperations.AddFloatParam("PRICE", membership.Price);

            return SqlOperations;
        }

        /* DELETE Methods */
        public SqlOperation DeleteStatements(BaseDTO Dto)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DEL_MEMBERSHIP_PR" };
            var membership = (Membership)Dto;
            sqlOperation.AddIntParam("ID", (int)membership.Id);
            return sqlOperation;
        }

        public SqlOperation GetDeleteStatements(int Id)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_MEMBERSHIP_PR" };
            operation.AddIntParam("Id", Id);
            return operation;
        }


        /* GET Methods */
        public SqlOperation GetRetrieveByIdStatements(int Id)
        {
            var sqlOperations = new SqlOperation();
            sqlOperations.ProcedureName = "RET_MEMBERSHIP_BY_ID_PR";
            sqlOperations.AddIntParam("Id", Id);
            return sqlOperations;
        }

        public SqlOperation GetRetrieveByUser(int Id)
        {
            var sqlOperations = new SqlOperation();
            sqlOperations.ProcedureName = "RET_EVENTS_COUNT_PR";
            sqlOperations.AddIntParam("Id", Id);
            return sqlOperations;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var sqlOperations = new SqlOperation();
            sqlOperations.ProcedureName = "RET_ALL_MEMBERSHIP_PR";
            return sqlOperations;
        }

        /* PUSH Methods */
        public SqlOperation GetUpdateStatements(BaseDTO Dto)
        {
            var SqlOperations = new SqlOperation();
            SqlOperations.ProcedureName = "UPD_MEMBERSHIP_PR";

            var membership = (Membership)Dto;
            SqlOperations.AddIntParam("Id", membership.Id);
            SqlOperations.AddVarcharParam("MEMBERSHIPNAME", membership.MembershipName);
            SqlOperations.AddVarcharParam("DESCRIPTION", membership.Description);
            SqlOperations.AddIntParam("TICKETLIMIT", membership.TicketLimit);
            SqlOperations.AddFloatParam("COMMISSION", membership.Commission);
            SqlOperations.AddIntParam("EVENTLIMIT", membership.EventLimit);
            SqlOperations.AddFloatParam("PRICE", membership.Price);

            return SqlOperations;
        }
        #endregion

        #region "Interface IObjectMapper (Construcción de objetos desde la BD)"
        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var membershipDTO = new Membership
            {
                Id = (int)row["IDMembership"],
                MembershipName = (string)row["MembershipName"],
                Description = (string)row["Description"],
                TicketLimit = (int)row["TicketLimit"],
                Commission = Convert.ToSingle(row["Commission"]),
                EventLimit = (int)row["EventLimit"],
                Price = Convert.ToSingle(row["Price"])
            };
            return membershipDTO;
        }
        /*
        public BaseDTO BuildObjectInt(Dictionary<int, int> row)
        {
            
            var count = 0;
            {
                Id = (int)row["EVENTS_CREATED"]
            };
            return count;
           
        }
         */
        public BaseDTO BuildObjectAcq(Dictionary<string, object> row)
        {
            var membershipAcq = new MembAcq
            {
                Id = (int)row["IDMembership"],
                UserId = (int)row["UserId"],
                MembershipName = (string)row["MembershipName"],
                Description = (string)row["Description"],
                TicketLimit = (int)row["TicketLimit"],
                Commission = Convert.ToSingle(row["Commission"]),
                EventLimit = (int)row["EventLimit"],
                Price = Convert.ToSingle(row["Price"]),
                StartDate = (DateTime)row["Start_Date"],
                EndDate = (DateTime)row["End_Date"],
            };
            return membershipAcq;
        }


        public SqlOperation RetrieveMyMembership(int Id) 
        {

            var sqlOperations = new SqlOperation();
            sqlOperations.ProcedureName = "RET_MEMBERSHIP_BY_ID_PR";
            sqlOperations.AddIntParam("Id", Id);
            return sqlOperations;

        }



        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseDTO>();

            foreach (var item in lstRows)
            {
                var membershipDTO = BuildObject(item);
                lstResults.Add(membershipDTO);
            }
            return lstResults;
        }

		public SqlOperation DeleteStatements(int Id)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}