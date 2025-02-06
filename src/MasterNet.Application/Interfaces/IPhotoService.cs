using MasterNet.Application.Fotos;
using Microsoft.AspNetCore.Http;

namespace MasterNet.Application.Interfaces
{
    public interface IPhotoService
    {
        Task<PhotoUploadResult> AddPhoto(IFormFile file);
        Task<string> DeletePhoto(string publicId);
    }
}