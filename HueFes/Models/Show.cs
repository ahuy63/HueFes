namespace HueFes.Models
{
    public class Show
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int ShowCategoryId { get; set; }
        public ShowCategory ShowCategory { get; set; }

    }
}
