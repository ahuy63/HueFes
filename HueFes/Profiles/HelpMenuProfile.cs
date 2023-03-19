using AutoMapper;
using HueFes.DomainModels;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class HelpMenuProfile : Profile
    {
        public HelpMenuProfile()
        {
            CreateMap<HelpMenuVM, HelpMenu>().ReverseMap();
            CreateMap<HelpMenuVM_Detail, HelpMenu>().ReverseMap();
            CreateMap<HelpMenuVM_Input, HelpMenu>().ReverseMap();
        }
    }
}
