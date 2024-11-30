

using AutoMapper;
using HRE.Application.DTOs.Permission;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository permissionRepository;
    private readonly IMapper mapper;
    public PermissionService(IPermissionRepository permissionRepository, IMapper mapper)
    {
        this.permissionRepository = permissionRepository;
        this.mapper = mapper;
    }

    public async Task<Permission?> Create(PermissionDTO entity)
    {
        return await permissionRepository.Create(mapper.Map<Permission>(entity));
    }

    public async Task<bool> Delete(int id)
    {
        return await permissionRepository.Delete(id);
    }

    public async Task<bool> Update(int id, PermissionDTO entity)
    {
        var entityToUpdate = await permissionRepository.GetByID(id);
        if (entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        return await permissionRepository.Update(entityToUpdate);
    }


    public async Task<PermissionGroup?> CreateGroup(GroupDTO entity)
    {
        return await permissionRepository.CreateGroup(mapper.Map<PermissionGroup>(entity));
    }

    public async Task<bool> UpdateGroup(int id, GroupDTO entity)
    {
        var entityToUpdate = await permissionRepository.GetGroupByID(id);
        if (entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        return await permissionRepository.UpdateGroup(entityToUpdate);
    }

    public async Task<bool> DeleteGroup(int id)
    {
        return await permissionRepository.DeleteGroup(id);
    }
}
