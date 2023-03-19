using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.DomainModels;
using HueFes.ViewModels;
using System;

namespace HueFes.Core.Services
{
    public class TicketService : ITicketService
    {
        public IUnitOfWork _unitOfWork;
        public ITicketTypeService _ticketTypeService;
        public TicketService(IUnitOfWork unitOfWork, ITicketTypeService ticketTypeService)
        {
            _unitOfWork = unitOfWork;
            _ticketTypeService = ticketTypeService;
        }

        public async Task<bool> BuyTicket(List<BuyTicketVM> inputList, int customerId)
        {
            try
            {
                var createdDate = DateTime.Now;
                foreach (var item in inputList)
                {
                    for (int i = 0; i < item.quantity; i++)
                    {
                        var ticket = new Ticket()
                        {
                            Code = await GenerateCode(),
                            TicketTypeId = item.TicketTypeId,
                            CustomerId = customerId,
                            Status = false, //true: chua kich hoat
                            CreatedDate= createdDate
                        };
                        await _unitOfWork.TicketRepository.Add(ticket);
                    }
                    await _ticketTypeService.UpdateTicketQuantity(item.TicketTypeId, -item.quantity); // tru so luong ve trong kho
                    //await UpdateTicketQuantity(item.TicketTypeId, item.quantity);
                }

                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<bool> CheckCode(string code)
        {
            if (await _unitOfWork.TicketRepository.GetByCode(code) != null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CancelTicket(int id)
        {
            try
            {
                var ticket = await _unitOfWork.TicketRepository.GetById(id);
                await _unitOfWork.TicketRepository.Delete(ticket);
                await _ticketTypeService.UpdateTicketQuantity(ticket.TicketTypeId, 1);//Tang luong ve trong kho
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _unitOfWork.TicketRepository.GetAllAsync();
        }

        public async Task<Ticket> GetById(int id)
        {
            return await _unitOfWork.TicketRepository.GetById(id);
        }

        public async Task<bool> Update(Ticket input)
        {
            try
            {
                await _unitOfWork.TicketRepository.Update(input);
                await _unitOfWork.CommitAsync(); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<string> GenerateCode()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var code = new string(Enumerable.Repeat(chars, 20)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            if (!await CheckCode(code))
            {
                return await GenerateCode();
            }
            return code;
        }

        public async Task<bool> CheckQuantity(int ticketTypeId, int buyQuantity)
        {
            var ticketType = await _unitOfWork.TicketTypeRepository.GetById(ticketTypeId);
            if (ticketType.Quantity < buyQuantity)
            {
                return false;
            }
            return true;
        }

        public async Task<Ticket> GetByCode(string code)
        {
            return await _unitOfWork.TicketRepository.GetByCode(code);
        }

    }
}
