namespace WebApp_MindTickets.Models.ViewModels
{
    public class VMMembership
    {
        public int Id { get; set; }
        public string? MembershipName { get; set; }
        public int TicketLimit { get; set; }
        public float Commission { get; set; }
        public int EventLimit { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
    }
}
