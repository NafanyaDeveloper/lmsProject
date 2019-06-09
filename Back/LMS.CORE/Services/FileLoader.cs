using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace LMS.CORE.Services
{
    public class FileLoader : IFileLoader
    {
        public async Task<string> LoadImg(string img, string type = "avatar", string rPath = null)
        {
            var bytes = Convert.FromBase64String(img);

            string path = rPath ?? ($"/{type}/" + Guid.NewGuid().ToString() + ".jpg");

            using (var imageFile = new FileStream(Directory.GetCurrentDirectory() + "/wwwroot" + path, FileMode.Create))
            {
                await imageFile.WriteAsync(bytes, 0, bytes.Length);
                await imageFile.FlushAsync();
            }
            

            return path;
        }
    }
}
