namespace HueFes.DomainModels
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string ImageURL { get; set; }
        public int Type { get; set; } = 3;                      //1: Event, 2: Location, 3: News
    }
}
