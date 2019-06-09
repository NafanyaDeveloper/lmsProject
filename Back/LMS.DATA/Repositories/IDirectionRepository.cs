using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Repositories
{
    public interface IDirectionRepository: IDisposable
    {
        Task<List<Direction>> GetAllAsync();
        Task<Direction> GetByIdAsync(Guid id);
        Task<Direction> CreateAsync(Direction item);
        Task<bool> UpdateAsync(Direction item);
        Task<bool> DeleteAsync(Guid id);
    }
}
