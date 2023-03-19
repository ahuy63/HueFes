namespace HueFes.DomainModels
{
    public class Checkin
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set;}
        public bool Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
