// File: ImageController.cs
using BusinessObject.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    private const string ImageUploadPath = "images";
    private readonly IWebHostEnvironment _hostingEnvironment;

    public ImageController(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }
    [HttpGet("{fileName}")]
    public IActionResult GetImage(string fileName)
    {
        string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, ImageUploadPath, fileName);
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("Không tìm thấy ảnh.");
        }

        var imageBytes = System.IO.File.ReadAllBytes(filePath);

        string contentType = GetContentType(fileName);

        return File(imageBytes, contentType);
    }

    private string GetContentType(string fileName)
    {
        switch (Path.GetExtension(fileName).ToLowerInvariant())
        {
            case ".jpg":
            case ".jpeg":
                return "image/jpeg";
            case ".png":
                return "image/png";
            case ".gif":
                return "image/gif";
            default:
                return "application/octet-stream";
        }
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadImage([FromForm] ImageUploadModel model)
    {
        if (model.ImageFile == null || model.ImageFile.Length == 0)
        {
            return BadRequest("Hình ảnh không hợp lệ.");
        }

        List<string> allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif" }; 

        string fileExtension = Path.GetExtension(model.ImageFile.FileName);

        if (string.IsNullOrEmpty(fileExtension) || !allowedExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase))
        {
            return BadRequest("Định dạng file không được hỗ trợ.");
        }
        string uploadPath = Path.Combine(_hostingEnvironment.ContentRootPath, ImageUploadPath);
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }
        string fileName = Path.GetRandomFileName() + fileExtension;
        string filePath = Path.Combine(uploadPath, fileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await model.ImageFile.CopyToAsync(stream);
        }
        return Ok(new { FilePath = filePath });
    }
    [HttpGet("encode/{input}")]
    public IActionResult EncodeString(string input)
    {
        string encodedString = Convert.ToBase64String(Encoding.UTF8.GetBytes(input));

        return Ok(new { EncodedString = encodedString });
    }

    [HttpGet("decode/{encodedString}")]
    public IActionResult DecodeString(string encodedString)
    {
        try
        {
            byte[] decodedBytes = Convert.FromBase64String(encodedString);
            string decodedString = Encoding.UTF8.GetString(decodedBytes);

            return Ok(new { DecodedString = decodedString });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = "Không thể giải mã chuỗi." + ex });
        }
    }
    public static string HashData(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }

    [HttpGet("hash/{input}")]
    public IActionResult HashString(string input)
    {
        string hashedString = HashData(input);

        return Ok(new { HashedString = hashedString });
    }

    [HttpGet("verify/{input}/{hashedString}")]
    public IActionResult VerifyHash(string input, string hashedString)
    {
        string hashedInput = HashData(input);

        if (hashedInput.Equals(hashedString, StringComparison.OrdinalIgnoreCase))
        {
            return Ok(new { VerificationResult = "Giá trị đã xác minh." });
        }
        else
        {
            return BadRequest(new { ErrorMessage = "Giá trị không khớp." });
        }
    }
   
}