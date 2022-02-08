using System.Threading.Tasks;

namespace App1.Services
{
    public interface IUploadServices
    {
        Task<string> UploadFile(string filePath, string fileKeyBucket);
        Task<string> UploadPhoto(string imagePath, string keyBucket);
    }
}
