using LMS.CORE.EF;
using LMS.CORE.Services;
using LMS.DATA.Entities;
using LMS.DATA.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.CORE.Repositories
{
    public class DirectionRepository: IDirectionRepository
    {
        public void Dispose() { }

        private readonly LMSContext _context;
        private readonly IFileLoader _loader;

        public DirectionRepository(LMSContext context, IFileLoader loader)
        {
            _context = context;
            _loader = loader;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<Direction> CreateAsync(Direction item)
        {
            if (item.LoadImg != null)
                item.Img = await _loader.LoadImg(item.LoadImg, "files");
            var result = await _context.Directions.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Direction direction = await GetByIdAsync(id);
            if (direction == null)
                return false;
            _context.Directions.Remove(direction);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Direction>> GetAllAsync()
        {
            return await _context.Directions.AsNoTracking().ToListAsync();
        }

        public async Task<Direction> GetByIdAsync(Guid id)
        {
            return await _context.Directions.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Direction item)
        {
            if (item.LoadImg != null)
                item.Img = await _loader.LoadImg(item.LoadImg, "files", item.Img);
            Direction direction = await GetByIdAsync(item.Id);
            if (direction == null)
                return false;
            _context.Directions.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
