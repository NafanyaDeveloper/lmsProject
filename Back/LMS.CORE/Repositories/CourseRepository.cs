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
    public class CourseRepository: ICourseRepository
    {
        public void Dispose() { }

        private readonly LMSContext _context;
        private readonly IFileLoader _loader;

        public CourseRepository(LMSContext context, IFileLoader loader)
        {
            _context = context;
            _loader = loader;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.AsNoTracking().ToListAsync();
        }

        public async Task<Course> GetByIdAsync(Guid id)
        {
            return await _context.Courses.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<List<Course>> GetByDirectionIdAsync(Guid id)
        {
            return await _context.Courses.AsNoTracking().Where(x => x.DirectionId == id).ToListAsync();
        }

        public async Task<Course> CreateAsync(Course item)
        {
            if (item.LoadImg != null)
                item.Img = await _loader.LoadImg(item.LoadImg, "files");
            var result = await _context.Courses.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> UpdateAsync(Course item)
        {
            if (item.LoadImg != null)
                item.Img = await _loader.LoadImg(item.LoadImg, "files", item.Img);
            Course course = await GetByIdAsync(item.Id);
            if (course == null)
                return false;
            _context.Courses.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Course course = await GetByIdAsync(id);
            if (course == null)
                return false;
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
