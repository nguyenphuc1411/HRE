﻿
namespace HRE.Domain.Entities;

public class RolePermission
{
    public int RoleId { get; set; }
    public Role Role { get; set; } = new();
    public int PermissionId { get; set; }
    public Permission Permission { get; set; }= new();
}
