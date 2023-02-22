using AutoMapper;
using HueFes.Models;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class ShowProfile : Profile
    {
        public ShowProfile() { 
            CreateMap<ShowCategoryVM, ShowCategory>().ReverseMap();
            CreateMap<ShowCategoryVM_Input, ShowCategory>().ReverseMap();
            CreateMap<ShowVM, Show>().ReverseMap();
            CreateMap<ShowVM_Input, Show>().ReverseMap();
            CreateMap<ShowVM_Detail, Show>().ReverseMap();
        }
    }
}
