using AutoMapper;
using HueFes.Models;
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
