using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    [HttpGet("{fileName}")]
    public IActionResult GetFile(string fileName)
    {
        var fileExtension = Path.GetExtension(fileName).ToLowerInvariant(); // Dosya uzantısını alın ve küçük harfe dönüştürün
        var filePath = Path.Combine("Uploads", fileName);

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound(); // Dosya bulunamadıysa 404 hatası döndür
        }

        var fileStream = System.IO.File.OpenRead(filePath);

        // MIME türünü dosya uzantısına göre belirle
        var contentType = GetContentType(fileExtension);

        return File(fileStream, contentType);
    }

    private string GetContentType(string fileExtension)
    {
        switch (fileExtension)
        {
            case ".jpg":
            case ".jpeg":
                return "image/jpeg";
            case ".png":
                return "image/png";
            case ".gif":
                return "image/gif";
            case ".pdf":
                return "application/pdf";
            // Diğer dosya türleri için ek case'ler ekleyebilirsiniz
            default:
                return "application/octet-stream"; // Genel dosya türü
        }
    }
}
