namespace HueFes.Models
{
    public class Favourite
    {
        public int Id { get; set; }
        public int? EventId { get; set; }
        public Event? Event { get; set; }
        public int? LocationId { get; set; }
        public Location? Location { get; set; }
        public int? NewsId { get; set; }
        public News? News { get; set; }
        public int Type { get; set; }
    }
}
