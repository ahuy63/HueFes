namespace HueFes.Models
{
    public class LocationCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; } = "Image URL...";

        public ICollection<Location> Locations { get; set; }
    }
}
