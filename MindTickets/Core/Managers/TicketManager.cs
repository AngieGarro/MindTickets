using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class TicketManager
    {
        public TicketManager() { }

        public List<MyTickets> RetrieveMyFutureEvents(int id)
        {
            var crud = new TicketCrudFactory();
            return crud.RetrieveMyFutureEvents<MyTickets>(id);

        }

        public List<MyTickets> RetrieveMyPastEvents(int id)
        {
            var crud = new TicketCrudFactory();
            return crud.RetrieveMyPastEvents<MyTickets>(id);

        }
    }
}
