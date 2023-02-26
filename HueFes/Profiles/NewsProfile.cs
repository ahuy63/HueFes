using AutoMapper;
using HueFes.Models;
using HueFes.ViewModels;

namespace HueFes.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<NewsVM, News>().ReverseMap();
            CreateMap<NewsVM_Input, News>().ReverseMap();
            CreateMap<NewsVM_Details, News>().ReverseMap();
        }
    }
}
