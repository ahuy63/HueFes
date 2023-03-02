using AutoMapper;
using HueFes.Models;
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
