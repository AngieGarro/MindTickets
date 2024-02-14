namespace WebApp_MindTickets.Models.ViewModels
{
	public class UserDTO
	{
		public string FullName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }
		public string? IDPicture { get; set; }
		public string? IDImage { get; set; }

		public string UserType { get; set; }
	}
}
