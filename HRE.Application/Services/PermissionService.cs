

using AutoMapper;
using HRE.Application.DTOs.Permission;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using System.Security;

namespace HRE.Application.Services;

public class PermissionService : IPermissionService
{
    private readonly IBaseRepository<Permission> permissionRepository;
    private readonly IBaseRepository<PermissionGroup> permissionGroupRepository;
    private readonly IMapper mapper;
    public PermissionService(IBaseRepository<Permission> permissionRepository, IMapper mapper, IBaseRepository<PermissionGroup> permissionGroupRepository)
    {
        this.permissionRepository = permissionRepository;
        this.mapper = mapper;
        this.permissionGroupRepository = permissionGroupRepository;
    }

    public async Task<Permission?> Create(PermissionDTO entity)
    {
        var permission = mapper.Map<Permission>(entity);
        await permissionRepository.AddAsync(permission);
        var result = await permissionRepository.SaveChangesAsync();
        return result>0? permission:null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await permissionRepository.GetByIdAsync(id);
        if (entityToDelete == null) return false;
        permissionRepository.Delete(entityToDelete);
        return await permissionRepository.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(int id, PermissionDTO entity)
    {
        var entityToUpdate = await permissionRepository.GetByIdAsync(id);
        if (entityToUpdate == null) return false;

        mapper.Map(entity, entityToUpdate);
        permissionRepository.Update(entityToUpdate);

        return await permissionRepository.SaveChangesAsync() > 0;
    }
    public async Task<Permission?> GetByID(int id)
    {
        return await permissionRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Permission>> GetAll()
    {
        return await permissionRepository.GetAllAsync();
    }

    // GROUP

    public async Task<PermissionGroup?> CreateGroup(GroupDTO entity)
    {
        var group = mapper.Map<PermissionGroup>(entity);
        await permissionGroupRepository.AddAsync(group);
        var result = await permissionGroupRepository.SaveChangesAsync();
        return result > 0 ? group : null;
    }

    public async Task<bool> UpdateGroup(int id, GroupDTO entity)
    {
        var entityToUpdate = await permissionGroupRepository.GetByIdAsync(id);
        if (entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        permissionGroupRepository.Update(entityToUpdate);
        return await permissionRepository.SaveChangesAsync()>0;
    }

    public async Task<bool> DeleteGroup(int id)
    {
        var entityToDelete = await permissionGroupRepository.GetByIdAsync(id);
        if (entityToDelete == null) return false;
        permissionGroupRepository.Delete(entityToDelete);
        return await permissionGroupRepository.SaveChangesAsync() > 0;
    }

    public async Task<PermissionGroup?> GetGroupByID(int id)
    {
        return await permissionGroupRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<PermissionGroup>> GetAllGroup()
    {
        return await permissionGroupRepository.GetAllAsync();
    }
}
