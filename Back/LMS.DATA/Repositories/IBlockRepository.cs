using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Repositories
{
    public interface IBlockRepository: IDisposable
    {
        Task<List<Block>> GetAllAsync();
        Task<Block> GetByIdAsync(Guid id);
        Task<List<Block>> GetByPageIdAsync(Guid id);
        Task<List<Block>> GetByBlockTypeIdAsync(Guid id);
        Task<Block> CreateAsync(Block item);
        Task<bool> UpdateAsync(Block item);
        Task<bool> DeleteAsync(Guid id);
    }
}
