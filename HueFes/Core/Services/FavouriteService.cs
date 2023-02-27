using AutoMapper;
using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.Models;
using HueFes.ViewModels;

namespace HueFes.Core.Services
{
    public class FavouriteService : IFavouriteService
    {
        public IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public FavouriteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FavouriteVM> GetAll()
        {
            var fav = _unitOfWork.FavouriteRepository.GetAllAsync();
            
            return new FavouriteVM
            {
                Events = _mapper.Map<ICollection<EventVM>>(await _unitOfWork.EventRepository.GetFavourite()),
                Locations = _mapper.Map<ICollection<LocationVM>>(await _unitOfWork.LocationRepository.GetFavourite()),
                News = _mapper.Map<ICollection<NewsVM>> (await _unitOfWork.NewsRepository.GetFavourite())
            };
        }
    }
}
