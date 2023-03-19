using AutoMapper;
using HueFes.DomainModels;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<StaffVM, Staff>().ReverseMap();
            CreateMap<StaffVM_Login, Staff>().ReverseMap();
            CreateMap<StaffVM_Update, Staff>().ReverseMap();
            CreateMap<Staff, StaffVM_Create>().ReverseMap();
                //.ForMember(dest => dest.Status, opt => opt.MapFrom(frm => frm.Status == "Chua kich hoat"? false: true));
        }
    }
}
