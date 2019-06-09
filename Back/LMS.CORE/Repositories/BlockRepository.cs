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
    public class BlockRepository : IBlockRepository
    {
        public void Dispose() { }

        private readonly LMSContext _context;
        private readonly IFileLoader _loader;


        public BlockRepository(LMSContext context, IFileLoader loader)
        {
            _context = context;
            _loader = loader;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public async Task<Block> CreateAsync(Block item)
        {
            if (item.LoadImg != null)
                item.Img = await _loader.LoadImg(item.LoadImg, "files");
            var result = await _context.Blocks.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Block block = await GetByIdAsync(id);
            if (block == null)
                return false;
            _context.Blocks.Remove(block);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Block>> GetAllAsync()
        {
            return await _context.Blocks.AsNoTracking().ToListAsync();
        }

        public async Task<List<Block>> GetByBlockTypeIdAsync(Guid id)
        {
            return await _context.Blocks.AsNoTracking().Where(x => x.BlockTypeId == id).ToListAsync();
        }

        public async Task<Block> GetByIdAsync(Guid id)
        {
            return await _context.Blocks.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<List<Block>> GetByPageIdAsync(Guid id)
        {
            return await _context.Blocks.AsNoTracking().Where(x => x.PageId == id).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Block item)
        {
            if (item.LoadImg != null)
                item.Img = await _loader.LoadImg(item.LoadImg, "files");
            Block block = await GetByIdAsync(item.Id);
            if (block == null)
                return false;
            _context.Blocks.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
