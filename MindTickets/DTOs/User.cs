using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class User : BaseDTO
	{
		public string? FullName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public string? Password { get; set; }
		public string? IDPicture { get; set; }
		public string? IDImage { get; set; }

		public string? UserType { get; set; }      
        public int? AuthenticatedOTP { get; set; }
        public string? Token { get; set; }
        public Address? Location { get; set; }

	}
}
