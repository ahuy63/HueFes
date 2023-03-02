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
            //var fav = await _unitOfWork.FavouriteRepository.GetAll();
            //return fav;
            return new FavouriteVM
            {
                Events = _mapper.Map<ICollection<EventVM>>(await _unitOfWork.FavouriteRepository.GetFavouriteEvent()),
                Locations = _mapper.Map<ICollection<LocationVM>>(await _unitOfWork.FavouriteRepository.GetFavouriteLocation()),
                News = _mapper.Map<ICollection<NewsVM>>(await _unitOfWork.FavouriteRepository.GetFavouriteNews())
            };
        }

        public async Task<Favourite> GetFavouriteEvent(int eventId)
        {
            return await _unitOfWork.FavouriteRepository.GetByEventId(eventId);
        }
        public async Task<Favourite> GetFavouriteLocation(int locationId)
        {
            return await _unitOfWork.FavouriteRepository.GetByLocationId(locationId);
        }
        public async Task<Favourite> GetFavouriteNews(int newsId)
        {
            return await _unitOfWork.FavouriteRepository.GetByNewsId(newsId);
        }
    }
}
