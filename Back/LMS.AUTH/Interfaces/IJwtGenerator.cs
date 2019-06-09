using LMS.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.AUTH.Interfaces
{
    public interface IJwtGenerator
    {
        Task<object> GenerateJwt(User user);
    }
}
