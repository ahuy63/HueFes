using AutoMapper;
using HueFes.DomainModels;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class TicketTypeProfile : Profile
    {
        public TicketTypeProfile()
        {
            CreateMap<TicketTypeVM, TicketType>().ReverseMap();
            CreateMap<TicketTypeVM_Input, TicketType>().ReverseMap();
        }
    }
}
