using AutoMapper;
using HRE.Application.DTOs.Role;
using HRE.Application.Extentions;
using HRE.Application.Interfaces;
using HRE.Application.Models;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRE.Application.Services;

public class RoleService:IRoleService
{
    private readonly IBaseRepository<Role> roleRepository;
    private readonly IBaseRepository<RolePermission> rolePermissionRepository;
    private readonly IMapper mapper;
    public RoleService(IBaseRepository<Role> roleRepository, IMapper mapper, 
        IBaseRepository<RolePermission> rolePermissionRepository)
    {
        this.roleRepository = roleRepository;
        this.mapper = mapper;
        this.rolePermissionRepository = rolePermissionRepository;
    }

    public async Task<Role?> Create(RoleDTO entity)
    {
        var role = mapper.Map<Role>(entity);
        await roleRepository.AddAsync(role);
        var result = await roleRepository.SaveChangesAsync();
        return result>0? role: null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await roleRepository.GetByIdAsync(id);
        if (entityToDelete == null) return false;
        roleRepository.Delete(entityToDelete);
        return await roleRepository.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(int id, RoleDTO entity)
    {
        var entityToUpdate = await roleRepository.GetByIdAsync(id);
        if (entityToUpdate == null) return false;

        mapper.Map(entity, entityToUpdate);
        roleRepository.Update(entityToUpdate);

        return await roleRepository.SaveChangesAsync() > 0;
    }

    public async Task<PaginatedModel<GetRoleDTO>> Get(QueryModel query)
    {
        return await roleRepository.AsQueryable().Select(x => new GetRoleDTO
        {
            Id = x.Id,
            RoleName=x.RoleName,
            Description =x.Description,
            TotalAccount = x.Users.Count()
        }).ApplyQuery(query,r=>r.RoleName);
    }

    public async Task<GetRoleDTO?> GetById(int id)
    {
        return await roleRepository.AsQueryable().Select(role=>new GetRoleDTO
        {
            Id = role.Id,
            RoleName = role.RoleName,
            Description = role.Description,
            TotalAccount = role.Users.Count()
        }).FirstOrDefaultAsync(x=>x.Id== id);     
    }

    // SỬ Lý Permission
    public async Task<bool> AddPermission(int roleID, List<int> permissionIDs)
    {
        await rolePermissionRepository.BeginTransactionAsync();
        try
        {
            var listRolePermissions = new List<RolePermission>();
            foreach (var item in permissionIDs)
            {
                listRolePermissions.Add(new RolePermission
                {
                    RoleId = roleID,
                    PermissionId = item
                });
            }
            await rolePermissionRepository.AddRangeAsync(listRolePermissions);
            var result = await rolePermissionRepository.SaveChangesAsync();
            if (result == listRolePermissions.Count())
            {
                // Luu thanh cong
                await rolePermissionRepository.CommitTransactionAsync();
                return true;
            }
            else
            {
                await rolePermissionRepository.RollbackTransactionAsync();
                return false;
            }
        }
        catch (Exception ex)
        {
            await rolePermissionRepository.RollbackTransactionAsync();
            throw new Exception(ex.Message);
        }       
    }

    public async Task<bool> DeletePermission(int roleID, List<int> permissionIDs)
    {
        await rolePermissionRepository.BeginTransactionAsync();
        try
        {
            var listRolePermissions = new List <RolePermission>();
            foreach (var item in permissionIDs)
            {
                listRolePermissions.Add(new RolePermission
                {
                    RoleId = roleID,
                    PermissionId = item
                });
            }
            rolePermissionRepository.DeleteRange(listRolePermissions);
            var result = await rolePermissionRepository.SaveChangesAsync();
            if (result==listRolePermissions.Count())
            {
                await rolePermissionRepository.CommitTransactionAsync();
                return true;
            }
            else
            {
                await rolePermissionRepository.RollbackTransactionAsync();
                return false;
            }
        }
        catch (Exception ex)
        {
            await rolePermissionRepository.RollbackTransactionAsync();
            throw new Exception(ex.Message);
        }
    }
}
