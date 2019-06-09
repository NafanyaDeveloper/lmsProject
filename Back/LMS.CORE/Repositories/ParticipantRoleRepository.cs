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
    public class ParticipantRoleRepository: IParticipantRoleRepository
    {
        public void Dispose() { }

        private readonly LMSContext _context;


        public ParticipantRoleRepository(LMSContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<ParticipantRole> CreateAsync(ParticipantRole item)
        {
            var result = await _context.ParticipantRoles.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            ParticipantRole pRole = await GetByIdAsync(id);
            if (pRole == null)
                return false;
            _context.ParticipantRoles.Remove(pRole);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ParticipantRole>> GetAllAsync()
        {
            return await _context.ParticipantRoles.AsNoTracking().ToListAsync();
        }

        public async Task<ParticipantRole> GetByIdAsync(Guid id)
        {
            return await _context.ParticipantRoles.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(ParticipantRole item)
        {
            ParticipantRole pRole = await GetByIdAsync(item.Id);
            if (pRole == null)
                return false;
            _context.ParticipantRoles.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
