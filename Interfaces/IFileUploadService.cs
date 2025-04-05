namespace AvtoElon.API.Demo.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(IFormFile file, int carId);
    }
}
