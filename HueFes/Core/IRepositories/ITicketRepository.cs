﻿using HueFes.Models;

namespace HueFes.Core.IRepositories
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        Task<Ticket?> GetByCode(string code);
    }
}
