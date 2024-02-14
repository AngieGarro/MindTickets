using DataAccess.DAO;
using DataAccess.Mapper;
using DTOs;

namespace DataAccess.CRUD
{
	public class UserCrudFactory : CrudFactory
	{
		UserMapper _mapper;
		public UserCrudFactory()
		{

			dao = SqlDAO.GetInstance();
			_mapper = new UserMapper();

		}

		public override void AddImages(BaseDTO dto)
		{
			throw new NotImplementedException();
		}

		/*Registro User*/
		public override void Create(BaseDTO dto)
		{
			var user = (User)dto;
			var SqlOperations = _mapper.GetCreateStatements(user);
			dao.ExecuteProcedure(SqlOperations);
		}

        public void CreateUserAdmi(BaseDTO dto)
        {
            var user = (User)dto;
            var SqlOperations = _mapper.GetCreateAdminStatements(user);
            dao.ExecuteProcedure(SqlOperations);
        }
        /*------------------------------------------------------------------*/
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

		public void DeleteById(int Id)
		{
            var SqlOperations = _mapper.DeleteIDStatements(Id);
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

		//Lista todos los usuarios / Dashboard Admi
		public override List<T> RetrieveAll<T>()
		{
			var lstUsers = new List<T>();
			var SqlOperation = _mapper.GetRetriveAllStatement();
			var lstResults = dao.ExecuteQueryProcedure(SqlOperation);

			if (lstResults.Count > 0)
			{
				// Invocamos Mapper para construir lista de objetos
				var objs = _mapper.BuildObjects(lstResults);

				foreach (var obj in objs)
				{
					lstUsers.Add((T)Convert.ChangeType(obj, typeof(T)));
				}
			}
			return lstUsers;
		}

		public override T RetrieveById<T>(int Id)
		{
			throw new NotImplementedException();
		}

		public override void Update(BaseDTO dto)
		{
			var user = (User)dto;
			var SqlOperation = _mapper.GetUpdateStatements(user);
			dao.ExecuteProcedure(SqlOperation);
		}
	}
}