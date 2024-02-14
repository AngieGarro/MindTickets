using DataAccess.CRUD;
using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
	public class MembershipManager
	{
		public MembershipManager() { }

		public void Create(Membership membership)
		{
			/* Guardo en DB */
			var crud = new MembershipCrudFactory();
			crud.Create(membership);
		}

		
		public void Delete(Membership membership)
		{
            
            var crud = new MembershipCrudFactory();
			crud.Delete(membership);
			
		}

        public void DeleteID(int Id)
        {
            var crud = new MembershipCrudFactory();
            crud.DeleteID(Id);
        }

        public void Update(Membership membership)
		{
			var crud = new MembershipCrudFactory();
			crud.Update(membership);
		}

		public List<Membership> RetrieveAll()
		{
			var crud = new MembershipCrudFactory();
			return crud.RetrieveAll<Membership>();
		}

		public Membership RetrieveById(Membership membership)
		{
			throw new NotImplementedException();
		}

		public MembAcq RetrieveMyMembership(int id)
		{
			var crud = new MembershipCrudFactory();
			return crud.RetrieveMyMembership<MembAcq>(id);

        }


    }

}