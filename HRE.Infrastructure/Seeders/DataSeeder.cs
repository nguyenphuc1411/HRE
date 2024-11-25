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
            if (!context.Roles.Any())
            {
                var roles = GetRoles();
                await context.Roles.AddRangeAsync(roles);              
            }
            if (context.Users.Any())
            {
                var user = GetUser();
                await context.Users.AddAsync(user);

                var userRole = GetUserRole();
                await context.UserRoles.AddAsync(userRole);
            }
            if (!context.PermissionGroups.Any())
            {
                var groups = GetGroups();
                await context.PermissionGroups.AddRangeAsync(groups);
            }
            if (!context.Permissions.Any())
            {
                var permissions = GetPermissions();
                await context.Permissions.AddRangeAsync(permissions);
            }

            await context.SaveChangesAsync();
        }
    }

    private UserRole GetUserRole()
    {
        return new UserRole
        {
            RoleId = 1,
            UserId = 1
        };
    }

    private IEnumerable<Permission> GetPermissions()
    {
        var permissions = new List<Permission>
            {
                // Dashboard
                new() { Id = 1, GroupId = 1, PermissionName = "Xem Dashboard" },

                // Quản lý Robot
                new() { Id = 2, GroupId = 2, PermissionName = "Xem danh sách Robot" },
                new() { Id = 3, GroupId = 2, PermissionName = "Tạo Robot mới" },
                new() { Id = 4, GroupId = 2, PermissionName = "Cập nhật thông tin Robot" },
                new() { Id = 5, GroupId = 2, PermissionName = "Xem chi tiết thông tin Robot" },
                new() { Id = 6, GroupId = 2, PermissionName = "Xóa Robot" },

                // Quản lý máy tái chế
                new() { Id = 7, GroupId = 3, PermissionName = "Xem danh sách máy tái chế" },
                new() { Id = 8, GroupId = 3, PermissionName = "Tạo máy tái chế mới" },
                new() { Id = 9, GroupId = 3, PermissionName = "Cập nhật thông tin máy tái chế" },
                new() { Id = 10, GroupId = 3, PermissionName = "Xem chi tiết thông tin máy tái chế" },
                new() { Id = 11, GroupId = 3, PermissionName = "Lịch sử thùng chứa" },
                new() { Id = 12, GroupId = 3, PermissionName = "Lịch sử thùng nước" },
                new() { Id = 13, GroupId = 3, PermissionName = "Xóa máy tái chế" },

                // Quản lý địa điểm
                new() { Id = 14, GroupId = 4, PermissionName = "Xem danh sách địa điểm" },
                new() { Id = 15, GroupId = 4, PermissionName = "Tạo địa điểm mới" },
                new() { Id = 16, GroupId = 4, PermissionName = "Cập nhật thông tin địa điểm" },
                new() { Id = 17, GroupId = 4, PermissionName = "Xem chi tiết thông tin địa điểm" },
                new() { Id = 18, GroupId = 4, PermissionName = "Xóa địa điểm" },

                // Quản lý quà tặng
                new() { Id = 19, GroupId = 5, PermissionName = "Xem danh sách quà tặng" },
                new() { Id = 20, GroupId = 5, PermissionName = "Tạo quà tặng mới" },
                new() { Id = 21, GroupId = 5, PermissionName = "Cập nhật thông tin quà tặng" },
                new() { Id = 22, GroupId = 5, PermissionName = "Xem chi tiết thông tin quà tặng" },
                new() { Id = 23, GroupId = 5, PermissionName = "Xóa quà tặng" },

                // Quản lý quy tắc trúng thưởng
                new() { Id = 24, GroupId = 6, PermissionName = "Xem danh sách quy tắc trúng thưởng" },
                new() { Id = 25, GroupId = 6, PermissionName = "Tạo quy tắc trúng thưởng mới" },
                new() { Id = 26, GroupId = 6, PermissionName = "Cập nhật thông tin quy tắc trúng thưởng" },
                new() { Id = 27, GroupId = 6, PermissionName = "Xem chi tiết thông tin quy tắc trúng thưởng" },
                new() { Id = 28, GroupId = 6, PermissionName = "Xóa quy tắc trúng thưởng" },

                // Vận hành chiến dịch
                new() { Id = 29, GroupId = 7, PermissionName = "Xem danh sách chiến dịch" },
                new() { Id = 30, GroupId = 7, PermissionName = "Tạo chiến dịch mới" },
                new() { Id = 31, GroupId = 7, PermissionName = "Cập nhật thông tin chiến dịch" },
                new() { Id = 32, GroupId = 7, PermissionName = "Xem chi tiết thông tin chiến dịch" },
                new() { Id = 33, GroupId = 7, PermissionName = "Xem thông tin trúng thưởng của quà tặng" },
                new() { Id = 34, GroupId = 7, PermissionName = "Cập nhật số lượng quà tặng" },
                new() { Id = 35, GroupId = 7, PermissionName = "Cập nhật trạng thái chiến dịch" },
                new() { Id = 36, GroupId = 7, PermissionName = "Lịch sử đối soát" },
                new() { Id = 37, GroupId = 7, PermissionName = "Xóa chiến dịch" },

                // Quản lý khách hàng
                new() { Id = 38, GroupId = 8, PermissionName = "Xem danh sách khách hàng" },
                new() { Id = 39, GroupId = 8, PermissionName = "Cập nhật thông tin khách hàng" },
                new() { Id = 40, GroupId = 8, PermissionName = "Xem chi tiết thông tin khách hàng" },

                // Quản lý khu vực
                new() { Id = 41, GroupId = 9, PermissionName = "Xem danh sách khu vực" },
                new() { Id = 42, GroupId = 9, PermissionName = "Tạo khu vực mới" },
                new() { Id = 43, GroupId = 9, PermissionName = "Cập nhật thông tin khu vực" },
                new() { Id = 44, GroupId = 9, PermissionName = "Xem chi tiết thông tin khu vực" },
                new() { Id = 45, GroupId = 9, PermissionName = "Xóa khu vực" },

                // Quản lý người dùng
                new() { Id = 46, GroupId = 10, PermissionName = "Xem danh sách người dùng" },
                new() { Id = 47, GroupId = 10, PermissionName = "Tạo người dùng mới" },
                new() { Id = 48, GroupId = 10, PermissionName = "Cập nhật thông tin người dùng" },
                new() { Id = 49, GroupId = 10, PermissionName = "Xem chi tiết thông tin người dùng" },
                new() { Id = 50, GroupId = 10, PermissionName = "Xóa người dùng" },

                // Quản lý vai trò
                new() { Id = 51, GroupId = 11, PermissionName = "Xem danh sách vai trò" },
                new() { Id = 52, GroupId = 11, PermissionName = "Tạo vai trò mới" },
                new() { Id = 53, GroupId = 11, PermissionName = "Cập nhật thông tin vai trò" },
                new() { Id = 54, GroupId = 11, PermissionName = "Xem chi tiết thông tin vai trò" },
                new() { Id = 55, GroupId = 11, PermissionName = "Xóa vai trò" },

                // Báo cáo
                new() { Id = 56, GroupId = 12, PermissionName = "Báo cáo Robot Silverbot" },
                new() { Id = 57, GroupId = 12, PermissionName = "Báo cáo Robot DeliveryBox" },
                new() { Id = 58, GroupId = 12, PermissionName = "Báo cáo máy tái chế" },
                new() { Id = 59, GroupId = 12, PermissionName = "Thống kê quà tặng" },
                new() { Id = 60, GroupId = 12, PermissionName = "Báo cáo PG" },
                new() { Id = 61, GroupId = 12, PermissionName = "Báo cáo chiến dịch" },

                // PG
                new() { Id = 62, GroupId = 13, PermissionName = "PG" }
            };
        return permissions;
    }

    private IEnumerable<PermissionGroup> GetGroups()
    {
        var groups = new List<PermissionGroup>
            {
                new() { Id = 1, GroupName = "Dashboard" },
                new() { Id = 2, GroupName = "Quản lý Robot" },
                new() { Id = 3, GroupName = "Quản lý máy tái chế" },
                new() { Id = 4, GroupName = "Quản lý địa điểm" },
                new() { Id = 5, GroupName = "Quản lý quà tặng" },
                new() { Id = 6, GroupName = "Quản lý quy tắc trúng thưởng" },
                new() { Id = 7, GroupName = "Vận hành chiến dịch" },
                new() { Id = 8, GroupName = "Quản lý khách hàng" },
                new() { Id = 9, GroupName = "Quản lý khu vực" },
                new() { Id = 10, GroupName = "Quản lý người dùng" },
                new() { Id = 11, GroupName = "Quản lý vai trò" },
                new() { Id = 12, GroupName = "Báo cáo" },
                new() { Id = 13, GroupName = "PG" }
            };
        return groups;
    }

    private User GetUser()
    {
        // Tạo đối tượng User
        var user = new User
        {
            Id = 1,
            Username = "admin",
            Fullname = "Nguyen Thanh Phuc",
            Email = "nguyenphuc14112003@gmail.com"
        };

        // Mã hóa mật khẩu
        var passwordHasher = new PasswordHasher<User>();
        user.PasswordHash = passwordHasher.HashPassword(user, "Phuc.1411");

        return user;
    }

    private IEnumerable<Role> GetRoles()
    {
        var roles = new List<Role>()
        {
            new Role
                {
                    Id = 1,
                    RoleName = "SYSTEMUSER",
                    Description = "Vai trò người dùng hệ thống"
                },
                 new Role
                {
                    Id = 2,
                    RoleName = "PG",
                    Description = "Vai trò nhân viên PG"
                },
                  new Role
                {
                    Id = 3,
                    RoleName = "CUSTOMER",
                    Description = "Vai trò khách hàng"
                }
        };
        return roles;
    }

}
