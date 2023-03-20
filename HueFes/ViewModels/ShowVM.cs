using HueFes.Models;
using System.ComponentModel.DataAnnotations;

namespace HueFes.ViewModels
{
    public class ShowVM
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int Type_Inoff { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int LocationId { get; set; }
        public string LocationTitle { get; set; }
    }
    public class ShowVM_ListByDate
    {
        public DateTime Date { get; set; }
        public ICollection<ShowVM> ShowList { get; set;}
    }
    public class ShowVM_Input
    {
        [Required]
        public int EventId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int Type_Inoff { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public int ShowCategoryId { get; set; }
    }
    public class ShowVM_Detail
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public string LocationTitle { get; set; }
        public int ShowCategoryId { get; set; }
        public string ShowCategoryName { get; set; }
    }
}
