using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Repositories
{
    public interface IAnswerRepository: IDisposable
    {
        Task<List<Answer>> GetAllAsync();
        Task<Answer> GetByIdAsync(Guid id);
        Task<List<Answer>> GetByQuestionIdAsync(Guid id);
        Task<Answer> CreateAsync(Answer item);
        Task<bool> UpdateAsync(Answer item);
        Task<bool> DeleteAsync(Guid id);
    }
}
