using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
	public class EventsManager
	{
        //CREA Y GUARDA TODO EL FLUJO DE DATOS PARA GENERAR UN EVENTO
        public void CreateEvents(Events ev)
        {
            /* Guardo en DB */
            var crud = new EventsCrudFactory();
            crud.Create(ev);
        }

        //_______________________Final del Create______________________
        //_____________________________________________________________
        public void Delete(Events ev)
        {
			var crud = new EventsCrudFactory();
			crud.Delete(ev);
		}
        public void Update(Events ev)
        {
			var crud = new EventsCrudFactory();
			crud.Update(ev);
		}

        //------- Listar los otros DTOS -----------
        public List<Events> RetrieveAll()
        {
            var crud = new EventsCrudFactory();
            return crud.RetrieveAll<Events>();
        }		
        public Events RetrieveById(Events ev)
        {
            throw new NotImplementedException();
        }

        public List<Events> RetrieveMyEvents(int id)
        {
            var crud = new EventsCrudFactory();
            return crud.RetrieveMyEvents<Events>(id);

        }

        public int RetrieveCount(int id) 
        {
            var crud = new EventsCrudFactory();

            return crud.RetrieveMyEventsAndReturnCount(id);
        }
    }
}
