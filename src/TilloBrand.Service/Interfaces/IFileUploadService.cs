using TilloBrand.Service.DTOs.Assets;

namespace TilloBrand.Service.Interfaces
{
    public interface IFileUploadService
    {
        public Task<AssetForResultDto> FileUploadAsync(AssetForCreationDto dto);
        public Task<bool> DeleteFileAsync(string filePath);
    }
}
