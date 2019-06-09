using LMS.CORE.EF;
using LMS.DATA.Entities;
using LMS.DATA.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.CORE.Repositories
{
    public class AdministrationRepository : IAdministrationRepository
    {
        public void Dispose() { }

        private readonly LMSContext _context;


        public AdministrationRepository(LMSContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<Administration> CreateAsync(Administration item)
        {
            var result = await _context.Administration.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid userId, Guid directionId)
        {
            Administration administration = await GetByIdAsync(userId, directionId);
            if (administration == null)
                return false;
            _context.Administration.Remove(administration);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Administration>> GetAllAsync()
        {
            return await _context.Administration.AsNoTracking().ToListAsync();
        }

        public async Task<List<Administration>> GetByDirectionIdAsync(Guid id)
        {
            return await _context.Administration.AsNoTracking().Where(x => x.DirectionId == id).ToListAsync();
        }

        public async Task<Administration> GetByIdAsync(Guid userId, Guid directionId)
        {
            return await _context.Administration.AsNoTracking().FirstAsync(x => x.UserId == userId && x.DirectionId == directionId);
        }

        public async Task<List<Administration>> GetByRoleIdAsync(Guid id)
        {
            return await _context.Administration.AsNoTracking().Where(x => x.AdministrationRoleId == id).ToListAsync();
        }

        public async Task<List<Administration>> GetByUserIdAsync(Guid id)
        {
            return await _context.Administration.AsNoTracking().Where(x => x.UserId == id).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Administration item)
        {
            Administration administration = await GetByIdAsync(item.UserId, item.DirectionId);
            if (administration == null)
                return false;
            _context.Administration.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
