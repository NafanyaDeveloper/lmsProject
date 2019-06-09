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
    public class ParticipantRepository : IParticipantRepository
    {
        public void Dispose() { }

        private readonly LMSContext _context;


        public ParticipantRepository(LMSContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<Participant> CreateAsync(Participant item)
        {
            var result = await _context.Participants.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid userId, Guid groupId)
        {
            Participant participant = await GetByIdAsync(userId, groupId);
            if (participant == null)
                return false;
            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Participant>> GetAllAsync()
        {
            return await _context.Participants.AsNoTracking().ToListAsync();
        }

        public async Task<List<Participant>> GetByGroupIdAsync(Guid id)
        {
            return await _context.Participants.AsNoTracking().Where(x => x.GroupId == id).ToListAsync();
        }

        public async Task<Participant> GetByIdAsync(Guid userId, Guid groupId)
        {
            return await _context.Participants.AsNoTracking().FirstAsync(x => x.UserId == userId && x.GroupId == groupId);
        }

        public async Task<List<Participant>> GetByRoleIdAsync(Guid id)
        {
            return await _context.Participants.AsNoTracking().Where(x => x.ParticipantRoleId == id).ToListAsync();
        }

        public async Task<List<Participant>> GetByUserIdAsync(Guid id)
        {
            return await _context.Participants.AsNoTracking().Where(x => x.UserId == id).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Participant item)
        {
            Participant participant = await GetByIdAsync(item.UserId, item.GroupId);
            if (participant == null)
                return false;
            _context.Participants.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
