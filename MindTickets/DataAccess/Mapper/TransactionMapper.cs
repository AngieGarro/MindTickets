using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    internal class TransactionMapper : ISqlStatements, IObjectMapper
    {
        
        public SqlOperation DeleteStatements(BaseDTO Dto)
        {
            throw new NotImplementedException();
        }

        public SqlOperation DeleteStatements(int Id)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetCreateStatements(BaseDTO Dto)
        {
            var SqlOperations = new SqlOperation();
            SqlOperations.ProcedureName = "CRE_TRANSACTION_PR";

            var transaction = (Transaction)Dto;
            SqlOperations.AddIntParam("ITEMID", transaction.MembID);
            SqlOperations.AddVarcharParam("USEREMAIL", transaction.UserEmail);
            SqlOperations.AddIntParam("USERID", transaction.UserId);
            SqlOperations.AddVarcharParam("TRANSACTIONID", transaction.IdTransaction);
            SqlOperations.AddVarcharParam("PROVIDER", transaction.Provider);
            SqlOperations.AddVarcharParam("STATUS", transaction.Status);
            SqlOperations.AddFloatParam("TOTALAMOUNT", transaction.TotalAmount);
            SqlOperations.AddFloatParam("TAX", transaction.TaxApplied);
            SqlOperations.AddFloatParam("FINALAMOUNT", transaction.FinalAmount);
            SqlOperations.AddVarcharParam("MERCHANT", transaction.Merchant);            

            return SqlOperations;
        }

        public SqlOperation GetRetrieveByIdStatements(int Id)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatements(BaseDTO Dto)
        {
            throw new NotImplementedException();
        }

        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var transactionDTO = new Transaction
            {
                /*
                Id = (int)row["IDMembership"],
                MembershipName = (string)row["MembershipName"],
                Description = (string)row["Description"],
                TicketLimit = (int)row["TicketLimit"],
                Commission = Convert.ToSingle(row["Commission"]),
                EventLimit = (int)row["EventLimit"],
                Price = Convert.ToSingle(row["Price"])
                */
            };
            return transactionDTO;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseDTO>();

            foreach (var item in lstRows)
            {
                var transactionDTO = BuildObject(item);
                lstResults.Add(transactionDTO);
            }
            return lstResults;
        }
    }
}
