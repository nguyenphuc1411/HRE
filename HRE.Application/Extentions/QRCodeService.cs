
using QRCoder;

namespace HRE.Application.Extentions;

public static class QRCodeService
{
    public static byte[] GenerateQRCode(string content)
    {
        byte[] QRCode = new byte[0];
        if (!string.IsNullOrEmpty(content))
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData data = qrCodeGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode bitmap = new BitmapByteQRCode(data);
            QRCode = bitmap.GetGraphic(20);
        }
        return QRCode;
    }

    public static async Task<string> SaveQRCodeToFile(byte[] qrCodeBytes, string fileName)
    {
        // Lấy thư mục wwwroot
        var wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        // Tạo thư mục để lưu nếu chưa có
        var folderPath = Path.Combine(wwwRootPath, "qrcodes");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Đường dẫn tệp ảnh QR code
        var filePath = Path.Combine(folderPath, fileName);

        // Lưu mã QR dưới dạng file PNG
        await File.WriteAllBytesAsync(filePath, qrCodeBytes);

        // Trả về đường dẫn URL tới file trong thư mục wwwroot
        return $"/qrcodes/{fileName}";
    }
}
