namespace HRE.Application.DTOs.Role;

public class GetRoleDTO
{
    public int Id { get; set; }
    public string RoleName { get; set; } = default!;
    public string Description { get; set; } = default!;

    public int TotalAccount { get; set; } = 0;
}
