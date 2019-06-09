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
    public class BlockTypeRepository : IBlockTypeRepository
    {
        public void Dispose() { }

        private readonly LMSContext _context;


        public BlockTypeRepository(LMSContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<BlockType> CreateAsync(BlockType item)
        {
            var result = await _context.BlockTypes.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            BlockType bType = await GetByIdAsync(id);
            if (bType == null)
                return false;
            _context.BlockTypes.Remove(bType);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<BlockType>> GetAllAsync()
        {
            return await _context.BlockTypes.AsNoTracking().ToListAsync();
        }

        public async Task<BlockType> GetByIdAsync(Guid id)
        {
            return await _context.BlockTypes.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(BlockType item)
        {
            BlockType bType = await GetByIdAsync(item.Id);
            if (bType == null)
                return false;
            _context.BlockTypes.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
