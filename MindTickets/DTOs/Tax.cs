using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Tax : BaseDTO
    {
        public string? TaxName { get; set; }
        public float? Amount { get; set; }
    }
}
