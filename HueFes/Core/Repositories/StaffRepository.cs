﻿using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(HueFesDbContext context) : base(context)
        {
        }

        public async Task<Staff?> GetByPhone(string phone)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Phone == phone);
        }

        public async Task<Staff?> Login(string phone, string password)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Phone == phone && x.Password == password);
        }
    }
}
