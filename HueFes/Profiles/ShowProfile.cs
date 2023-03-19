using AutoMapper;
using HueFes.DomainModels;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class ShowProfile : Profile
    {
        public ShowProfile() { 
            CreateMap<ShowCategoryVM, ShowCategory>().ReverseMap();
            CreateMap<ShowCategoryVM_Input, ShowCategory>().ReverseMap();
            CreateMap<ShowCategoryVM_Detail, ShowCategory>().ReverseMap();
            CreateMap<ShowVM, Show>().ReverseMap()
                .ForMember(dest => dest.Type_Inoff, opt => opt.MapFrom(frm => frm.Event.Type_Inoff))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(frm => frm.Event.Type_Inoff == 1 ? "Chuong trinh co ban ve" : "Chuong trinh khong ban ve"))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(frm => frm.Event.Price));
            CreateMap<ShowVM_Input, Show>().ReverseMap();
            CreateMap<ShowVM_Detail, Show>().ReverseMap();
        }
    }
}
