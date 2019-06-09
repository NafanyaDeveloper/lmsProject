using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Repositories
{
    public interface IBlockTypeRepository: IDisposable
    {
        Task<List<BlockType>> GetAllAsync();
        Task<BlockType> GetByIdAsync(Guid id);
        Task<BlockType> CreateAsync(BlockType item);
        Task<bool> UpdateAsync(BlockType item);
        Task<bool> DeleteAsync(Guid id);
    }
}
