using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class TaxMapper : IObjectMapper, ISqlStatements
    {

        public SqlOperation DeleteStatements(BaseDTO Dto)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DEL_TAX_PR" };
            var tax = (Tax)Dto;
            sqlOperation.AddIntParam("ID", (int)tax.Id);
            return sqlOperation;
        }

        public SqlOperation GetCreateStatements(BaseDTO Dto)
        {
            var SqlOperations = new SqlOperation();
            SqlOperations.ProcedureName = "CRE_TAX_PR";

            var tax = (Tax)Dto;
            SqlOperations.AddVarcharParam("TAXNAME", tax.TaxName);
            SqlOperations.AddFloatParam("AMOUNT", (double)tax.Amount);

            return SqlOperations;

        }

        public SqlOperation GetRetrieveByIdStatements(int Id)
        {
            var sqlOperations = new SqlOperation();
            sqlOperations.ProcedureName = "RET_TAX_BY_ID_PR";
            sqlOperations.AddIntParam("Id", Id);
            return sqlOperations;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var sqlOperations = new SqlOperation();
            sqlOperations.ProcedureName = "RET_ALL_TAX_PR";
            return sqlOperations;
        }

        public SqlOperation GetUpdateStatements(BaseDTO Dto)
        {
            var SqlOperations = new SqlOperation();
            SqlOperations.ProcedureName = "UPD_TAX_PR";

            var tax = (Tax)Dto;
            SqlOperations.AddIntParam("Id", tax.Id);
            SqlOperations.AddVarcharParam("TAXNAME", tax.TaxName);
            SqlOperations.AddFloatParam("AMOUNT", (double)tax.Amount);
   

            return SqlOperations;
        }       

        public SqlOperation DeleteStatements(int Id)
        {
            throw new NotImplementedException();
        }


        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var userDTO = new Tax
            {
                Id = (int)row["IdTax"],
                TaxName = (string)row["TaxName"],
                Amount = Convert.ToSingle(row["Amount"]),
            };

            return userDTO;
        }

        public List<BaseDTO> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseDTO>();
            foreach (var item in lstRows)
            {
                var taxDTO = BuildObject(item);
                lstResults.Add(taxDTO);
            }
            return lstResults;
        }
    }
}
