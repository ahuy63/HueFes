using HueFes.Models;

namespace HueFes.ViewModels
{
    public class ShowVM
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int Type_Inoff { get; set; }

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
        public int EventId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Type_Inoff { get; set; }
        public int LocationId { get; set; }
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
