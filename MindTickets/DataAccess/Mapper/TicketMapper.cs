using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class TicketMapper : ISqlStatements, IObjectMapper
    {
        public MyTickets BuildObject(Dictionary<string, object> row)
        {
            var myTickets = new MyTickets
            {
                Logo = (string)row["Logo"],
                EventName = (string)row["EventName"],
                EventTime = (string)row["DateAndTime"],
                Province = (string)row["Province"],
                Canton = (string)row["Canton"],
                District = (string)row["District"],
                ExactAddress = (string)row["ExactAddress"],
                TicketSeatInfo = (string)row["TicketTypeId"],
                SeatNumber = (string)row["SeatId"],
            };
            return myTickets;
        }

        public List<MyTickets> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<MyTickets>();

            foreach (var item in lstRows)
            {
                var myTickets = BuildObject(item);
                lstResults.Add(myTickets);
            }
            return lstResults;
        }

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
            throw new NotImplementedException();
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

        public SqlOperation GetRetrieveMyFutureEvents(int Id)
        {

            var sqlOperations = new SqlOperation();
            sqlOperations.ProcedureName = "RET_MY_FUTURE_EVENTS_PR";
            sqlOperations.AddIntParam("Id", Id);
            return sqlOperations;

        }

        public SqlOperation GetRetrieveMyPastEvents(int Id)        {

            var sqlOperations = new SqlOperation();
            sqlOperations.ProcedureName = "RET_MY_PAST_EVENTS_PR";
            sqlOperations.AddIntParam("Id", Id);
            return sqlOperations;

        }

        BaseDTO IObjectMapper.BuildObject(Dictionary<string, object> row)
        {
            throw new NotImplementedException();
        }

        List<BaseDTO> IObjectMapper.BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            throw new NotImplementedException();
        }
    }
}
