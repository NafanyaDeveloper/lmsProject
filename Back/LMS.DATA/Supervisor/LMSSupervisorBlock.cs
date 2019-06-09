using LMS.DATA.Converters;
using LMS.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Supervisor
{
    public partial class LMSSupervisor
    {
        public async Task<List<BlockDto>> GetAllBlockAsync()
        {
            return BlockConverter.Convert(await _blockRepo.GetAllAsync());
        }

        public async Task<BlockDto> GetBlockByIdAsync(Guid id)
        {
            BlockDto block = BlockConverter.Convert(await _blockRepo.GetByIdAsync(id));
            block.BlockTypeName = _blockTypeRepo.GetByIdAsync(block.BlockTypeId).Result.Name;
            block.PageName = _pageRepo.GetByIdAsync(block.PageId).Result.Name;
            block.Questions = QuestionConverter.Convert(await _questionRepo.GetByBlockIdAsync(id));
            return block;
        }

        public async Task<List<BlockDto>> GetBlockByPageIdAsync(Guid id)
        {
            return BlockConverter.Convert(await _blockRepo.GetByPageIdAsync(id));
        }

        public async Task<List<BlockDto>> GetBlockByBlockTypeIdAsync(Guid id)
        {
            return BlockConverter.Convert(await _blockRepo.GetByBlockTypeIdAsync(id));
        }

        public async Task<BlockDto> CreateBlockAsync(BlockDto item)
        {
            return BlockConverter.Convert(await _blockRepo.CreateAsync(BlockConverter.Convert(item)));
        }

        public async Task<bool> UpdateBlockAsync(BlockDto item)
        {
            return await _blockRepo.UpdateAsync(BlockConverter.Convert(item));
        }

        public async Task<bool> DeleteBlockAsync(Guid id)
        {
            return await _blockRepo.DeleteAsync(id);
        }
    }
}
