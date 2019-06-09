using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Repositories
{
    public interface IQuestionRepository: IDisposable
    {
        Task<List<Question>> GetAllAsync();
        Task<Question> GetByIdAsync(Guid id);
        Task<List<Question>> GetByBlockIdAsync(Guid id);
        Task<Question> CreateAsync(Question item);
        Task<bool> UpdateAsync(Question item);
        Task<bool> DeleteAsync(Guid id);
    }
}
