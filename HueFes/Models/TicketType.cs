namespace HueFes.Models
{
    public class TicketType
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public string Zone { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
