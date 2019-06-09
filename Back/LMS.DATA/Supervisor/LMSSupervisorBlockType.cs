using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Supervisor
{
    public partial class LMSSupervisor
    {
        public async Task<List<BlockType>> GetAllBlockTypeAsync()
        {
            return await _blockTypeRepo.GetAllAsync();
        }

        public async Task<BlockType> GetBlockTypeByIdAsync(Guid id)
        {
            BlockType block = await _blockTypeRepo.GetByIdAsync(id);
            block.Blocks = await _blockRepo.GetByBlockTypeIdAsync(id);
            return block;
        }

        public async Task<BlockType> CreateBlockTypeAsync(BlockType item)
        {
            return await _blockTypeRepo.CreateAsync(item);
        }

        public async Task<bool> UpdateBlockTypeAsync(BlockType item)
        {
            return await _blockTypeRepo.UpdateAsync(item);
        }

        public async Task<bool> DeleteBlockTypeAsync(Guid id)
        {
            return await _blockTypeRepo.DeleteAsync(id);
        }
    }
}
