using HueFes.Models;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Zone is required")]
        public string Zone { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
    }
}
