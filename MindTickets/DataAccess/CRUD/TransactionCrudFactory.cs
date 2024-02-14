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
    public class TransactionCrudFactory : CrudFactory
    {
        TransactionMapper _mapper;

        public TransactionCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new TransactionMapper();
        }
        public override void AddImages(BaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public override void Create(BaseDTO dto)
        {
            var transaction = (Transaction)dto;
            var SqlOperations = _mapper.GetCreateStatements(transaction);
            dao.ExecuteProcedure(SqlOperations);
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
