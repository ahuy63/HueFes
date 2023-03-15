using AutoMapper;
using HueFes.Models;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class CheckinProfile : Profile
    {
        public CheckinProfile()
        {
            CreateMap<CheckinVM, Checkin>().ReverseMap()
                .ForMember(dest => dest.ChuongTrinhId, opt => opt.MapFrom(frm => frm.Ticket.Type.Show.Event.Id))
                .ForMember(dest => dest.ChuongTrinh, opt => opt.MapFrom(frm => frm.Ticket.Type.Show.Event.Name))
                .ForMember(dest => dest.ticketCode, opt => opt.MapFrom(frm => frm.Ticket.Code))
                .ForMember(dest => dest.NgaySoatVe, opt => opt.MapFrom(frm => frm.DateCreated.ToShortDateString()))
                .ForMember(dest => dest.ThoiGian, opt => opt.MapFrom(frm => frm.DateCreated.ToShortTimeString()))
                .ForMember(dest => dest.LoaiVe, opt => opt.MapFrom(frm => frm.Ticket.Type.Zone))
                .ForMember(dest => dest.NhanVienSoatVe, opt => opt.MapFrom(frm => frm.Staff.Name))
                .ForMember(dest => dest.GiaVe, opt => opt.MapFrom(frm => frm.Ticket.Type.Price))
                .ForMember(dest => dest.TrangThai, opt => opt.MapFrom(frm => frm.Status? "Hop Le":"Khong Hop Le"))
                ;
        }
    }
}
