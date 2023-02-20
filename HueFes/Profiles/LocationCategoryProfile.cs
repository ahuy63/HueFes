using AutoMapper;
using HueFes.Models;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class LocationCategoryProfile : Profile
    {
        public LocationCategoryProfile()
        {
            CreateMap<LocationCategoryVM_Input,LocationCategory>().ReverseMap();
            CreateMap<LocationCategoryVM,LocationCategory>().ReverseMap();
            CreateMap<LocationCategoryVM_Detail,LocationCategory>().ReverseMap();
        }
    }
}
