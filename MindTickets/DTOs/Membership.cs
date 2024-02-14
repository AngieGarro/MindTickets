using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Membership : BaseDTO
    {
        public string? MembershipName { get; set; }
        public int TicketLimit { get; set; }
        public float Commission { get; set; }
        public int EventLimit { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }


    }
}