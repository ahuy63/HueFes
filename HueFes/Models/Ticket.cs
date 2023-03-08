namespace HueFes.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int TicketTypeId { get; set; }
        public TicketType Type { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
