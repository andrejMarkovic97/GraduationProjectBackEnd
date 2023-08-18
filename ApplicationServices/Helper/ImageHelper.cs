using Microsoft.AspNetCore.Http;

namespace ApplicationServices.Helper;

public static class ImageHelper
{
    private static readonly string ProjectRootPath = Directory.GetCurrentDirectory();
    private static readonly string UploadsFolder = Path.Combine(ProjectRootPath, "wwwroot", "images");
    public static async void UploadImage(string fileName, IFormFile image)
    {
       
        if (!Directory.Exists(UploadsFolder))
        {
            Directory.CreateDirectory(UploadsFolder);
        }
        string filePath = Path.Combine(UploadsFolder, fileName);

         using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(fileStream);
        }
    }

    public static string GetPath(string fileName)
    {
        return Path.Combine(UploadsFolder, fileName);
    }
}