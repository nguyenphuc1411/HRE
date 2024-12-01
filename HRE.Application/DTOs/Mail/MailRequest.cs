namespace HRE.Application.DTOs.Mail;

public class MailRequest
{
    public string ToEmail { get; set; } = default!;
    public string Subject { get; set; } = default!;
    public string Body { get; set; } = default!;
    public List<Attachment>? Attachments { get; set; }
}

public class Attachment
{
    public string FileName { get; set; } = default!;
    public byte[] FileData { get; set; } = default!;
    public string ContentType { get; set; } = default!;
}
