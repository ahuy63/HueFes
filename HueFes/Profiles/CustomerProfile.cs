using AutoMapper;
using HueFes.DomainModels;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerVM, Customer>().ReverseMap();
            CreateMap<CustomerVM_Create, Customer>().ReverseMap();
            CreateMap<CustomerVM_Login, Customer>().ReverseMap();
            CreateMap<CustomerVM_Update, Customer>().ReverseMap();
            CreateMap<CustomerVM_Detail, Customer>().ReverseMap();
        }
    }
}
