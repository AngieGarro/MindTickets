using DataAccess.DAO;
using DataAccess.Mapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class TicketCrudFactory : CrudFactory
    {
        TicketMapper _mapper;

        public TicketCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new TicketMapper();
        }

        public override void AddImages(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public override void Create(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public override void Create(BaseDTO dto, BaseDTO dto1)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public override void DeleteID(int Id)
        {
            throw new NotImplementedException();
        }

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
            throw new NotImplementedException();
        }

        public List<T> RetrieveMyPastEvents<T>(int Id)
        {
            var lstTickets = new List<T>();
            var SqlOperation = _mapper.GetRetrieveMyPastEvents(Id);
            var lstResults = dao.ExecuteQueryProcedure(SqlOperation);

            if (lstResults.Count > 0)
            {
                // Invocamos Mapper para construir lista de objetos
                var objs = _mapper.BuildObjects(lstResults);

                foreach (var obj in objs)
                {
                    lstTickets.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }
            return lstTickets;
        }

        public List<T> RetrieveMyFutureEvents<T>(int Id)
        {
            var lstTickets = new List<T>();
            var SqlOperation = _mapper.GetRetrieveMyFutureEvents(Id);
            var lstResults = dao.ExecuteQueryProcedure(SqlOperation);

            if (lstResults.Count > 0)
            {
                // Invocamos Mapper para construir lista de objetos
                var objs = _mapper.BuildObjects(lstResults);

                foreach (var obj in objs)
                {
                    lstTickets.Add((T)Convert.ChangeType(obj, typeof(T)));
                }
            }
            return lstTickets;
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