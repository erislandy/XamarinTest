using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    public class UploadServices : IUploadServices
    {

        public UploadServices()
        {

        }
        public async Task<string> UploadFile(string filePath, string fileKeyBucket)
        {

            return await Task.FromResult("");
        }

        public async Task<string> UploadPhoto(string imagePath, string keyBucket)
        {
            return await Task.FromResult("");
        }
    }
}
