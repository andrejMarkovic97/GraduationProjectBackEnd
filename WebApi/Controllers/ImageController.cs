using ApplicationServices.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetImage(string filename)
        {
            var filePath = ImageHelper.GetPath(filename);
            return PhysicalFile(filePath, "image/jpeg"); 
        }
    }
}
