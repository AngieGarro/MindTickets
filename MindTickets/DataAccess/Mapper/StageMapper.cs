using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class StageMapper : ISqlStatements, IObjectMapper
    {

        public BaseDTO BuildObject(Dictionary<string, object> row)
        {
            var StageDTO = new Seat
            {
                IdEvent = (int)row["IdEvent"],
                IdStage = (int)row["IdStage"],
                seatNumber = (string)row["SeatNumber"],
                sectorId = (int)row["SectionId"],
                active = (int)row["Active"],
                idClient = (int)row["IdClient"]
        };

            return StageDTO;
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
            operation.AddIntParam("ID", user.Id);
            return operation;

        }
        /* Add*/
        public SqlOperation GetCreateStatements(BaseDTO Dto)
        {
			throw new NotImplementedException();
		}
        public BaseDTO BuildObjectSeat(Dictionary<string, object> row)
        {
            var StageDTO = new Seat
            {
                seatNumber = (string)row["SeatNumber"],
                active = (int)row["Active"],
                idClient = (int)row["IdClient"]

            };

            return StageDTO;
        }

        public SqlOperation GetRetrieveByIdStatements(int pIdEvent, int pIdStage, int pSectorId)
        {
            var sqlOperations = new SqlOperation();
            sqlOperations.ProcedureName = "RET_SEAT_BY_ID_PR";

            sqlOperations.AddIntParam("IdEvent", pIdEvent);
            sqlOperations.AddIntParam("IdStage", pIdStage);
            sqlOperations.AddIntParam("SectorId", pSectorId);

            return sqlOperations;
        }

        public SqlOperation GetRetrieveByIdStatements(int Id)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var sqlOperations = new SqlOperation();
            sqlOperations.ProcedureName = "RET_SEAT_PR";
            return sqlOperations;
        }

        public SqlOperation GetUpdateStatements(BaseDTO Dto)
        {
			throw new NotImplementedException();
		}

        public SqlOperation DeleteStatements(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

