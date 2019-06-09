using LMS.CORE.EF;
using LMS.CORE.Services;
using LMS.DATA.Converters;
using LMS.DATA.Entities;
using LMS.DATA.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.CORE.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Dispose() { }

        private readonly UserManager<User> _userManager;
        private readonly IFileLoader _loader;

        public UserRepository(UserManager<User> userManager, IFileLoader loader)
        {
            _userManager = userManager;
            _loader = loader;
        }

        public async Task<User> CreateAsync(User item, string password)
        {
            if (password == null)
                return null;
            if (item.LoadImg != null)
                item.Avatar = await _loader.LoadImg(item.LoadImg);
            var result = await _userManager.CreateAsync(item, password);
            if (!result.Succeeded)
                return null;
            return await _userManager.FindByEmailAsync(item.Email);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            User user = await GetByIdAsync(id);
            if (user == null)
                return false;
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userManager.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _userManager.Users.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(User item)
        {
            if (item.LoadImg != null)
                item.Avatar = await _loader.LoadImg(item.LoadImg, "avatar", item.Avatar);
            User user = await GetByIdAsync(item.Id);
            if (user == null)
                return false;
            UserConverter.Convert(ref user, item);
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}
