using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    // Clase "Padre" de todos lo DTOs de la arquitectura
    // Todo DTO debe heredar esta clase.
    public class BaseDTO
    {
        public int Id { get; set; }

    }
}
