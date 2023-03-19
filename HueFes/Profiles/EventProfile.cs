using AutoMapper;
using HueFes.DomainModels;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile() {
            CreateMap<EventVM, Event>().ReverseMap();
            CreateMap<EventVM_Input, Event>().ReverseMap();
            CreateMap<EventVM_Detail, Event>().ReverseMap();


            CreateMap<EventImageVM, EventImage>().ReverseMap();
        }
    }
}
