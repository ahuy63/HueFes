using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.DomainModels;
using HueFes.ViewModels;

namespace HueFes.Core.Services
{
    public class CheckinService : ICheckinService
    {
        public IUnitOfWork _unitOfWork;
        public CheckinService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<dynamic?> CheckCode(int showId, string code)
        {
            try
            {
                var ticket = await _unitOfWork.TicketRepository.CheckCode(showId, code);
                if (ticket == null)                                                             //Khong tim thay ve
                {
                    return new { message = "Ve khong hop le!!!", trangThai = false };
                }
                if (ticket.Status)                                                              //Ve da kich hoat
                {
                    return new { message = "Ve da kich hoat tu truoc!!!", trangThai = false };
                }
                //if (ticket.Type.Show.StartDate < DateTime.UtcNow)
                //{
                //    return new { message = "Ve da het han", trangThai = false };
                //}

                return new { ticket, trangThai = true };
            }
            catch (Exception)
            {
                return new { message = "Loi he thong", trangThai = false };
            }
        }

        public async Task<bool> AddCheckinHistory(Checkin checkin)
        {
            try
            {
                await _unitOfWork.CheckinRepository.Add(checkin);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Checkin>> GetAll()
        {
            return await _unitOfWork.CheckinRepository.GetAllAsync();
        }

        public Task<Checkin> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Checkin checkin)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Checkin>> GetAllByStaffId(int staffId)
        {
            return await _unitOfWork.CheckinRepository.GetAllByStaffId(staffId);
        }

        public async Task<List<BaoCaoDetailsVM>> GetBaoCao(int staffId)
        {
            try
            {
                var baoCaos = await _unitOfWork.CheckinRepository.GetBaoCao(staffId);
                return baoCaos;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
