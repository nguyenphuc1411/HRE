
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
}
