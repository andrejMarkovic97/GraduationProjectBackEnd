using Microsoft.AspNetCore.Http;

namespace ApplicationServices.Helper;

public static class ImageHelper
{
    private static readonly string ProjectRootPath = Directory.GetCurrentDirectory();
    private static readonly string UploadsFolder = Path.Combine(ProjectRootPath, "wwwroot", "images");
    public static async void UploadImage(Guid id, IFormFile image)
    {
        var fileName = id + "_" + image.FileName;
        if (!Directory.Exists(UploadsFolder))
        {
            Directory.CreateDirectory(UploadsFolder);
        }
        
        var filesWithIdSubstring = Directory.GetFiles(UploadsFolder)
            .Where(file => Path.GetFileName(file).Contains(id.ToString()));
        
        //If an image already exists - delete it
        foreach (var existingFilePath in filesWithIdSubstring)
        {
            File.Delete(existingFilePath);
        }
        
        var filePath = Path.Combine(UploadsFolder, fileName);

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