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
    public class PageRepository : IPageRepository
    {
        public void Dispose() { }

        private readonly LMSContext _context;


        public PageRepository(LMSContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<Page> CreateAsync(Page item)
        {
            var result = await _context.Pages.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Page page = await GetByIdAsync(id);
            if (page == null)
                return false;
            _context.Pages.Remove(page);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Page>> GetAllAsync()
        {
            return await _context.Pages.AsNoTracking().ToListAsync();
        }

        public async Task<List<Page>> GetByCourseIdAsync(Guid id)
        {
            return await _context.Pages.AsNoTracking().Where(x => x.CourseId == id).ToListAsync();
        }

        public async Task<Page> GetByIdAsync(Guid id)
        {
            return await _context.Pages.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Page item)
        {
            Page page = await GetByIdAsync(item.Id);
            if (page == null)
                return false;
            _context.Pages.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
