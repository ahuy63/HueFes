namespace HueFes.ViewModels
{
    public class FavouriteVM
    {
        public ICollection<EventVM> Events { get; set; }
        public ICollection<LocationVM> Locations { get; set; }
        public ICollection<NewsVM> News { get; set; }
    }
}
