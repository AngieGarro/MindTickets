using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class StageManager
    {
        public StageManager() { }

        //public void CreateUser(User user)
        //{

        //    var crud = new UserCrudFactory();
        //    crud.Create(user);
        //}

        //public void Delete(User user)
        //{
        //    var crud = new UserCrudFactory();
        //    crud.Delete(user);
        //}


        //public void Update(User user)
        //{
        //    var crud = new MembershipCrudFactory();
        //    crud.Update(user);
        //}

        public List<Seat> RetrieveAll()
        {
            var crud = new StageCrudFactory();
            return crud.RetrieveAll<Seat>();
        }

        public List<Seat> RetrieveById(int IdEvent, int IdStage, int SectorId)
        {
            var crud = new StageCrudFactory();
            return crud.RetrieveById<Seat>(IdEvent, IdStage, SectorId);
        }
    }
}
