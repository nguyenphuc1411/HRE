using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;

        public ImagesController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] IFormFile file)
        {
            if (!IsImageValid(file))
                return BadRequest("This file is invalid for image");

            try
            {
                var newFilename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                var fullPath = Path.Combine(environment.WebRootPath, "Images", newFilename);

                using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fs);
                }

                return Ok(new { FilePath = newFilename });
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo lỗi
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }


        [HttpDelete("{filePath}")]
        public ActionResult Delete([FromRoute] string filePath)
        {
            try
            {
                var fullPath = Path.Combine(environment.WebRootPath,"Images", filePath);

                if (!System.IO.File.Exists(fullPath))
                {
                    return NotFound("File not found.");
                }

                // Xóa file
                System.IO.File.Delete(fullPath);

                return Ok("File deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }


        private bool IsImageValid(IFormFile file)
        {
            if (file == null || file.Length == 0) return false;

            var extensionFile = Path.GetExtension(file.FileName)?.ToLower();

            var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };

            if (allowedExtensions.Contains(extensionFile))
            {
                return true;
            }
            return false;
        }
    }
}
