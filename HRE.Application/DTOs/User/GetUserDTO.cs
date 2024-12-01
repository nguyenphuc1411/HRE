namespace HRE.Application.DTOs.User;

public class GetUserDTO
{
    public int Id { get; set; }
    public string Fullname { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public bool Status { get; set; } = false;
    public DateTime DateAdded { get; set; }

    public int RoleId { get; set; }
    public string RoleName { get; set; }= default!;
}
