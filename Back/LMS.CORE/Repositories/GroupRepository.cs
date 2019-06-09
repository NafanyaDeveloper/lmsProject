using LMS.CORE.EF;
using LMS.CORE.Services;
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
    public class GroupRepository : IGroupRepository
    {
        public void Dispose() { }

        private readonly LMSContext _context;


        public GroupRepository(LMSContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<Group> CreateAsync(Group item)
        {
            var result = await _context.Groups.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Group group = await GetByIdAsync(id);
            if (group == null)
                return false;
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await _context.Groups.AsNoTracking().ToListAsync();
        }

        public async Task<List<Group>> GetByCourseIdAsync(Guid id)
        {
            return await _context.Groups.AsNoTracking().Where(x => x.CourseId == id).ToListAsync();
        }

        public async Task<Group> GetByIdAsync(Guid id)
        {
            return await _context.Groups.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Group item)
        {
            Group group = await GetByIdAsync(item.Id);
            if (group == null)
                return false;
            _context.Groups.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
