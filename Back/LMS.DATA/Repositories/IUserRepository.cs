using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.DATA.Repositories
{
    public interface IUserRepository: IDisposable
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<User> CreateAsync(User item, string password);
        Task<bool> UpdateAsync(User item);
        Task<bool> DeleteAsync(Guid id);
    }
}
