using AutoMapper;
using HRE.Application.DTOs.Role;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class RoleService:IRoleService
{
    private readonly IRoleRepository roleRepository;
    private readonly IMapper mapper;
    public RoleService(IRoleRepository roleRepository, IMapper mapper)
    {
        this.roleRepository = roleRepository;
        this.mapper = mapper;
    }

    public async Task<Role> Create(RoleDTO entity)
    {
        var result = await roleRepository.Create(mapper.Map<Role>(entity));
        return result;
    }

    public async Task<bool> Delete(int id)
    {
        return await roleRepository.Delete(id);
    }

    public async Task<bool> Update(int id, RoleDTO entity)
    {
        var entityToUpdate = await roleRepository.GetByID(id);
        if (entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        return await roleRepository.Update(entityToUpdate);
    }
}
