using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.Models;
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

        public Task<IEnumerable<Ticket>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Ticket input)
        {
            throw new NotImplementedException();
        }

        //public async Task UpdateTicketQuantity(int ticketTypeId, int quantity)
        //{
        //    try
        //    {
        //        var ticketType = await _unitOfWork.TicketTypeRepository.GetById(ticketTypeId);
        //        ticketType.Quantity -= quantity;
        //        await _unitOfWork.TicketTypeRepository.Update(ticketType);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

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
    }
}
