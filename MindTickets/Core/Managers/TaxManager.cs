using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class TaxManager
    {
        public TaxManager() { }

        public void Create(Tax tax)
        {
            var crud = new TaxCrudFactory();
            crud.Create(tax);
        }

        public List<Tax> RetrieveAll()
        {
            var crud = new TaxCrudFactory();
            return crud.RetrieveAll<Tax>();
        }

        public Tax RetrieveById(int id)
        {
            var crud = new TaxCrudFactory();
            return crud.RetrieveIVId<Tax>(id);

        }

        public void Delete(Tax tax)
        {
            var crud = new TaxCrudFactory();
            crud.Delete(tax);
        }

        public void Update(Tax tax)
        {
            var crud = new TaxCrudFactory();
            crud.Update(tax);
        }
    }
}
