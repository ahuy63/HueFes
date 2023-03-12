using AutoMapper;
using HueFes.Models;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class CheckinProfile : Profile
    {
        public CheckinProfile()
        {
            CreateMap<CheckinVM, Checkin>().ReverseMap();
        }
    }
}
