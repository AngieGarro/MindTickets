using DataAccess.DAO;
using DataAccess.Mapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class StageCrudFactory : CrudFactory
    {
        StageMapper _mapper;
        public StageCrudFactory()
        {

            dao = SqlDAO.GetInstance();
            _mapper = new StageMapper();

        }

        public override void AddImages(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        /* Add*/
        public override void Create(BaseDTO dto)
        {
            var user = (User)dto;
            var SqlOperations = _mapper.GetCreateStatements(user);
            dao.ExecuteProcedure(SqlOperations);
        }

        public void Create(global::DTOs.User user)
        {
            throw new NotImplementedException();
        }

        public override void Create(BaseDTO dto, BaseDTO dto1)
        {
            throw new NotImplementedException();
        }

        /* Delete*/
        public override void Delete(BaseDTO dto)
        {
            var user = (User)dto;
            var SqlOperations = _mapper.DeleteStatements(user);
            dao.ExecuteProcedure(SqlOperations);
        }

        public override void DeleteID(int Id)
        {
            throw new NotImplementedException();
        }

        /* Get*/

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();

        }

        public override T Retrieve<T>(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstSeat = new List<T>();
            var SqlOperation = _mapper.GetRetriveAllStatement();
            var lstResults = dao.ExecuteQueryProcedure(SqlOperation);

            if (lstResults.Count > 0 )
            {
                var objs = _mapper.BuildObjects(lstResults);

                foreach (var obj in objs)
                {
                    lstSeat.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }
            return lstSeat;
        }

        public List<T> RetrieveById<T>(int IdEvent, int IdStage, int SectorId)
        {


            var seats = new List<T>();
            var SqlOperation = _mapper.GetRetrieveByIdStatements(IdEvent, IdStage, SectorId);
            var result = dao.ExecuteQueryProcedure(SqlOperation);

            if (result.Count > 0)
            {

                foreach (var results in result)
                {
                    var obj = _mapper.BuildObjectSeat(results);
                    var seat = (T)Convert.ChangeType(obj, typeof(T));
                    seats.Add(seat);
                }

                /*var obj = _mapper.BuildObjectSeat(result[0]);
                seats.Add((T)Convert.ChangeType(obj, typeof(T)));*/
            }

            return seats;
        }


        public override T RetrieveById<T>(int Id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
