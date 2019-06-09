using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Repositories
{
    public interface ICourseRepository: IDisposable
    {
        Task<List<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(Guid id);
        Task<List<Course>> GetByDirectionIdAsync(Guid id);
        Task<Course> CreateAsync(Course item);
        Task<bool> UpdateAsync(Course item);
        Task<bool> DeleteAsync(Guid id);
    }
}
