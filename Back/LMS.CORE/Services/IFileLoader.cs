using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.CORE.Services
{
    public interface IFileLoader
    {
        Task<string> LoadImg(string img, string type = "avatar", string rPath = null);
    }
}
