using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Repositories
{
    public interface IPageRepository: IDisposable
    {
        Task<List<Page>> GetAllAsync();
        Task<Page> GetByIdAsync(Guid id);
        Task<List<Page>> GetByCourseIdAsync(Guid id);
        Task<Page> CreateAsync(Page item);
        Task<bool> UpdateAsync(Page item);
        Task<bool> DeleteAsync(Guid id);
    }
}
