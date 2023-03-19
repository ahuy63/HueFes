using AutoMapper;
using HueFes.DomainModels;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class FavouriteProfile : Profile
    {
        public FavouriteProfile()
        {
            CreateMap<FavouriteVM, Favourite>().ReverseMap();
            CreateMap<Event, FavouriteVM>().ReverseMap();
            CreateMap<Location, FavouriteVM>().ReverseMap();
            CreateMap<News, FavouriteVM>().ReverseMap();
        }
    }
}
