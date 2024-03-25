using Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.FileService;
public class UploadHandler
{
    public FileCourseDocument Upload(IFormFile file)
    {
        FileCourseDocument fileCourseDocument = new FileCourseDocument();
        List<string> validExtensions = new List<string>() { ".jpg", ".png", ".gif", ".jpeg" };
        string extension = Path.GetExtension(file.FileName);
        if (!validExtensions.Contains(extension))
        {
            fileCourseDocument.Error = $"Extension is not valid ({string.Join(", ", validExtensions)})";
            return fileCourseDocument;
        }
        long size = file.Length;
        if (size > (5 * 1024 * 1024))
        {
            fileCourseDocument.Error = "Maximum size can be 5mb";
            return fileCourseDocument;
        }
        string fileName = Guid.NewGuid().ToString() + extension;
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        Directory.CreateDirectory(path); // Create directory if it doesn't exist
        FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
        fileCourseDocument.FileName = fileName;
        fileCourseDocument.FileExtension = extension;
        fileCourseDocument.FileSize = size;

        file.CopyTo(stream);
        stream.Dispose();
        stream.Close();
        return fileCourseDocument;
    }
}