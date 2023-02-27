using AutoMapper;
using HueFes.Models;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class FavouriteProfile : Profile
    {
        public FavouriteProfile()
        {
            CreateMap<FavouriteVM, Favourite>().ReverseMap();
        }
    }
}
