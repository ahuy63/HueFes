using AutoMapper;
using HueFes.DomainModels;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class LocationProfile :Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationVM, Location>().ReverseMap();
            CreateMap<LocationVM_Input, Location>().ReverseMap();
        }
    }
}
