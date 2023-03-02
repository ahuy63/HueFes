using HueFes.Models;

namespace HueFes.ViewModels
{
    public class TicketTypeVM
    {
        public int Id { get; set; }
        public string Zone { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
    public class TicketTypeVM_Input
    {
        public string Zone { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
