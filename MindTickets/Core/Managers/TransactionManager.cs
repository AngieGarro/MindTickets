using DataAccess.CRUD;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Managers
{
    public class TransactionManager
    {
        public TransactionManager() { }

        public void Create(Transaction transaction)
        {
            /* Guardo en DB */
            var crud = new TransactionCrudFactory();
            crud.Create(transaction);
        }
    }
}
