using AutoMapper;
using HRE.Application.DTOs.User;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HRE.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<User?> Create(UserDTO entity)
    {
        // Kiem tra username va email
        var check = await userRepository.GetByCondition(x => x.Email == entity.Email || x.Username == entity.Username);
        if (check != null) return null;

        var passwordHasher = new PasswordHasher<User>();
        var user = mapper.Map<User>(entity);
        user.Password = passwordHasher.HashPassword(user, entity.Password);
        return await userRepository.Create(user);
    }

    public async Task<bool> Delete(int id)
    {
        return await userRepository.Delete(id);
    }


    public async Task<bool> Update(int id, UserDTO entity)
    {
        var user = await userRepository.GetByID(id);
        if (user == null) return false;

        mapper.Map(entity, user);
        var passwordHasher = new PasswordHasher<User>();
        user.Password = passwordHasher.HashPassword(user, entity.Password);
        return await userRepository.Update(user);
    }

    public async Task<List<GetUserDTO>> Get()
    {
        var data = await userRepository.GetAll();
        var result = data.Select(x => new GetUserDTO
        {
            Id = x.Id,
            Fullname = x.Fullname,
            Email = x.Email,
            Username = x.Username,
            Status = x.Status,
            DateAdded = x.DateAdded,
            RoleId = x.RoleId,
            RoleName = x.Role.RoleName
        }).ToList();

        return result;
    }

    public async Task<GetUserDTO?> GetById(int id)
    {
        var data = await userRepository.GetByIDQuery(id);
        if (data == null) return null;
        var result = new GetUserDTO
        {
            Id = data.Id,
            Fullname = data.Fullname,
            Email = data.Email,
            Username = data.Username,
            Status = data.Status,
            DateAdded = data.DateAdded,
            RoleId = data.RoleId,
            RoleName = data.Role.RoleName
        };
        return result;
    }

    public async Task<List<string>> GetRolePermissions(int userId)
    {
        var result = new List<string>();

        var data = await userRepository.GetPermissions(userId);
        if (data != null)
        {
            result = data.Role.RolePermissions
          .Select(x => x.Permission.PermissionName)
          .ToList();
        }
        return result;
    }
}
