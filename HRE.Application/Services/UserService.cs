using AutoMapper;
using HRE.Application.DTOs.User;
using HRE.Application.Extentions;
using HRE.Application.Interfaces;
using HRE.Application.Models;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HRE.Application.Services;

public class UserService : IUserService
{
    private readonly IBaseRepository<User> userRepository;
    private readonly IMapper mapper;
    public UserService(IBaseRepository<User> userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<User?> Create(UserDTO entity)
    {
        // Kiem tra username va email
        var check = await userRepository.FindAsync(x => x.Email == entity.Email || x.Username == entity.Username);
        if (check!=null) return null;

        var passwordHasher = new PasswordHasher<User>();
        var user = mapper.Map<User>(entity);
        user.Password = passwordHasher.HashPassword(user, entity.Password);
        await userRepository.AddAsync(user);
        var result = await userRepository.SaveChangesAsync();
        return result > 0 ? user : null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await userRepository.GetByIdAsync(id);
        if (entityToDelete == null) return false;
        userRepository.Delete(entityToDelete);
        return await userRepository.SaveChangesAsync() > 0;
    }


    public async Task<bool> Update(int id, UserDTO entity)
    {
        var user = await userRepository.GetByIdAsync(id);
        if (user == null) return false;

        mapper.Map(entity, user);
        var passwordHasher = new PasswordHasher<User>();
        user.Password = passwordHasher.HashPassword(user, entity.Password);
        userRepository.Update(user);
        return await userRepository.SaveChangesAsync()>0;
    }

    public async Task<PaginatedModel<GetUserDTO>> Get(QueryModel query)
    {
        return await userRepository.AsQueryable().Select(x => new GetUserDTO
        {
            Id = x.Id,
            Fullname = x.Fullname,
            Email = x.Email,
            Username = x.Username,
            Status = x.Status,
            DateAdded = x.DateAdded,
            RoleId = x.RoleId,
            RoleName = x.Role.RoleName
        }).ApplyQuery(query,u=>u.Email);
    }

    public async Task<GetUserDTO?> GetById(int id)
    {
        return await userRepository.AsQueryable()
            .Where(x => x.Id == id).Select(data => new GetUserDTO
            {
                Id = data.Id,
                Fullname = data.Fullname,
                Email = data.Email,
                Username = data.Username,
                Status = data.Status,
                DateAdded = data.DateAdded,
                RoleId = data.RoleId,
                RoleName = data.Role.RoleName
            }).FirstOrDefaultAsync();       
    }

    public async Task<IEnumerable<string>> GetRolePermissions(int userId)
    {
        var permissions = await userRepository.AsQueryable()
            .Where(x => x.Id == userId)
            .SelectMany(x => x.Role.RolePermissions)
            .Select(rp => rp.Permission.PermissionName)
            .ToListAsync();

        return permissions;
    }


    // Quay thưởng


}
