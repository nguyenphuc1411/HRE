using HRE.Domain.Entities;
using HRE.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace HRE.Infrastructure.Seeders;

internal class DataSeeder(AppDbContext context) : IDataSeeder
{
    public async Task Seed()
    {
        if (await context.Database.CanConnectAsync())
        {
            if (!context.PermissionGroups.Any())
            {
                var groups = GetGroups();
                await context.PermissionGroups.AddRangeAsync(groups);
                await context.SaveChangesAsync();
            }
            if (!context.Roles.Any())
            {
                var roles = GetRoles();
                await context.Roles.AddRangeAsync(roles);
                await context.SaveChangesAsync();
            }
        }
    }
    private IEnumerable<PermissionGroup> GetGroups()
    {
        var groups = new List<PermissionGroup>
    {
        // Dashboard
        CreatePermissionGroup("Dashboard", new[] { "Xem Dashboard" }),

        // Quản lý Robot
        CreatePermissionGroup("Quản lý Robot", new[]
        {
            "Xem danh sách Robot",
            "Tạo Robot mới",
            "Cập nhật thông tin Robot",
            "Xem chi tiết thông tin Robot",
            "Xóa Robot"
        }),

        // Quản lý máy tái chế
        CreatePermissionGroup("Quản lý máy tái chế", new[]
        {
            "Xem danh sách máy tái chế",
            "Tạo máy tái chế mới",
            "Cập nhật thông tin máy tái chế",
            "Xem chi tiết thông tin máy tái chế",
            "Lịch sử thùng chứa",
            "Lịch sử thùng nước",
            "Xóa máy tái chế"
        }),

        // Quản lý địa điểm
        CreatePermissionGroup("Quản lý địa điểm", new[]
        {
            "Xem danh sách địa điểm",
            "Tạo địa điểm mới",
            "Cập nhật thông tin địa điểm",
            "Xem chi tiết thông tin địa điểm",
            "Xóa địa điểm"
        }),

        // Quản lý quà tặng
        CreatePermissionGroup("Quản lý quà tặng", new[]
        {
            "Xem danh sách quà tặng",
            "Tạo quà tặng mới",
            "Cập nhật thông tin quà tặng",
            "Xem chi tiết thông tin quà tặng",
            "Xóa quà tặng"
        }),

        // Quản lý quy tắc trúng thưởng
        CreatePermissionGroup("Quản lý quy tắc trúng thưởng", new[]
        {
            "Xem danh sách quy tắc trúng thưởng",
            "Tạo quy tắc trúng thưởng mới",
            "Cập nhật thông tin quy tắc trúng thưởng",
            "Xem chi tiết thông tin quy tắc trúng thưởng",
            "Xóa quy tắc trúng thưởng"
        }),

        // Vận hành chiến dịch
        CreatePermissionGroup("Vận hành chiến dịch", new[]
        {
            "Xem danh sách chiến dịch",
            "Tạo chiến dịch mới",
            "Cập nhật thông tin chiến dịch",
            "Xem chi tiết thông tin chiến dịch",
            "Xem thông tin trúng thưởng của quà tặng",
            "Cập nhật số lượng quà tặng",
            "Xem lịch sử cập nhật quà tặng",
            "Cập nhật trạng thái chiến dịch",
            "Lịch sử đối soát",
            "Xóa chiến dịch"
        }),

        // Quản lý khách hàng
        CreatePermissionGroup("Quản lý khách hàng", new[]
        {
            "Xem danh sách khách hàng",
            "Cập nhật thông tin khách hàng",
            "Xem chi tiết thông tin khách hàng"
        }),

        // Quản lý khu vực
        CreatePermissionGroup("Quản lý khu vực", new[]
        {
            "Xem danh sách khu vực",
            "Tạo khu vực mới",
            "Cập nhật thông tin khu vực",
            "Xem chi tiết thông tin khu vực",
            "Xóa khu vực"
        }),

        // Quản lý người dùng
        CreatePermissionGroup("Quản lý người dùng", new[]
        {
            "Xem danh sách người dùng",
            "Tạo người dùng mới",
            "Cập nhật thông tin người dùng",
            "Xem chi tiết thông tin người dùng",
            "Xóa người dùng"
        }),

        // Quản lý vai trò
        CreatePermissionGroup("Quản lý vai trò", new[]
        {
            "Xem danh sách vai trò",
            "Tạo vai trò mới",
            "Cập nhật thông tin vai trò",
            "Xem chi tiết thông tin vai trò",
            "Xóa vai trò"
        }),

        // Báo cáo
        CreatePermissionGroup("Báo cáo", new[]
        {
            "Robot Silverbot",
            "Robot DeliveryBox",
            "Máy tái chế",
            "Thống kê quà tặng",
            "Báo cáo PG",
            "Báo cáo chiến dịch"
        }),

        // PG
        CreatePermissionGroup("PG", new string[] { "PG" })
    };

        return groups;
    }

    private PermissionGroup CreatePermissionGroup(string groupName, string[] permissions)
    {
        var permissionList = permissions.Select(permission => new Permission { PermissionName = permission }).ToList();
        return new PermissionGroup
        {
            GroupName = groupName,
            Permissions = permissionList
        };
    }

    private IEnumerable<Role> GetRoles()
    {
        var user = new User
        {
            Username = "admin",
            Fullname = "Nguyen Thanh Phuc",
            Email = "nguyenphuc14112003@gmail.com",
            Status = true
        };

        // Mã hóa mật khẩu
        var passwordHasher = new PasswordHasher<User>();
        user.Password = passwordHasher.HashPassword(user, "Phuc.1411");

        var roles = new List<Role>
    {
        new Role
        {
            RoleName = "SYSTEMUSER",
            Description = "Vai trò người dùng hệ thống",
            Users = new List<User> { user },
            RolePermissions = GetSystemUserPermissions() // Thêm quyền cho SYSTEMUSER
        },
        new Role
        {
            RoleName = "PG",
            Description = "Vai trò nhân viên PG",
            RolePermissions = GetPGPermissions() // Thêm quyền cho PG
        },
        new Role
        {
            RoleName = "CUSTOMER",
            Description = "Vai trò khách hàng",
            RolePermissions = new List<RolePermission>() // Không có quyền cho khách hàng
        }
    };

        return roles;
    }

    private List<RolePermission> GetSystemUserPermissions()
    {
        var permissions = context.Permissions.Where(x=>x.PermissionName!="PG").ToList(); // Lấy tất cả quyền từ bảng Permissions
        return permissions.Select(p => new RolePermission
        {
            PermissionId = p.Id
        }).ToList();
    }

    private List<RolePermission> GetPGPermissions()
    {
        var permissions = context.Permissions.Where(p => p.PermissionName == "PG").ToList();
        return permissions.Select(p => new RolePermission
        {
            PermissionId = p.Id
        }).ToList();
    }
}
