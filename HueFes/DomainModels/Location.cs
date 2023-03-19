namespace HueFes.DomainModels
{
    public class Location
    {
        public int Id { get; set; }
        public int LocationCategoryId { get; set; }
        public LocationCategory Category { get; set; }

        public string Title { get; set; }
        public string Summary { get; set; }
        public string? Content { get; set; }
        public string Image { get; set; }

        public int Type { get; set; } = 2;                            //1: Event, 2: Location, 3: News
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
    }
}
