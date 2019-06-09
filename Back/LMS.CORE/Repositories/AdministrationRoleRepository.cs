using LMS.CORE.EF;
using LMS.DATA.Entities;
using LMS.DATA.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.CORE.Repositories
{
    public class AdministrationRoleRepository : IAdministrationRoleRepository
    {
        public void Dispose() { }

        private readonly LMSContext _context;


        public AdministrationRoleRepository(LMSContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<AdministrationRole> CreateAsync(AdministrationRole item)
        {
            var result = await _context.AdministrationRoles.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            AdministrationRole aRole = await GetByIdAsync(id);
            if (aRole == null)
                return false;
            _context.AdministrationRoles.Remove(aRole);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<AdministrationRole>> GetAllAsync()
        {
            return await _context.AdministrationRoles.AsNoTracking().ToListAsync();
        }

        public async Task<AdministrationRole> GetByIdAsync(Guid id)
        {
            return await _context.AdministrationRoles.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(AdministrationRole item)
        {
            AdministrationRole aRole = await GetByIdAsync(item.Id);
            if (aRole == null)
                return false;
            _context.AdministrationRoles.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
