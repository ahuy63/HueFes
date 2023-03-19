using AutoMapper;
using HueFes.DomainModels;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<TicketVM, Ticket>().ReverseMap()
                .ForMember(dest => dest.Ngay, opt => opt.MapFrom(frm => frm.Type.Show.StartDate.ToShortDateString()))
                .ForMember(dest => dest.ThoiGian, opt => opt.MapFrom(frm => frm.Type.Show.StartDate.ToShortTimeString()))
                .ForMember(dest => dest.ShowId, opt => opt.MapFrom(frm => frm.Type.ShowId))
                .ForMember(dest => dest.ShowName, opt => opt.MapFrom(frm => frm.Type.Show.Event.Name))
                .ForMember(dest => dest.LoaiVe, opt => opt.MapFrom(frm => frm.Type.Zone))
                .ForMember(dest => dest.GiaTien, opt => opt.MapFrom(frm => frm.Type.Price))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(frm => frm.Status ? "Da kich hoat" : "Chua kich hoat"));
        }
    }
}
