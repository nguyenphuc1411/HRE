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

    public async Task<Role?> Create(RoleDTO entity)
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

    public async Task<List<GetRoleDTO>> Get()
    {
       var data = await roleRepository.GetAll();
        var result = data.Select(x => new GetRoleDTO
        {
            Id = x.Id,
            RoleName=x.RoleName,
            Description =x.Description,
            TotalAccount = x.Users.Count()
        }).ToList();
        return result;
    }

    public async Task<GetRoleDTO?> GetById(int id)
    {
        var data = await roleRepository.GetByIDQuery(id);
        if (data == null) return null;
        var result = new GetRoleDTO
        {
            Id = data.Id,
            RoleName = data.RoleName,
            Description = data.Description,
            TotalAccount = data.Users.Count()
        };
        return result;
    }


    // SỬ Lý Permission

    public async Task<bool> AddPermission(int roleID, List<int> permissionIDs)
    {
        await roleRepository.BeginTransaction();
        try
        {
            foreach (var item in permissionIDs)
            {
                var newEntity = new RolePermission()
                {
                    RoleId = roleID,
                    PermissionId = item
                };
                var result = await roleRepository.AddPermission(newEntity);
                if (result == null)
                {
                    await roleRepository.RollbackTransaction();
                    return false;
                }
            }
            await roleRepository.CommitTransaction();
            return true;
        }
        catch (Exception ex)
        {
            await roleRepository.RollbackTransaction();
            throw new Exception(ex.Message);
        }       
    }

    public async Task<bool> DeletePermission(int roleID, List<int> permissionIDs)
    {
        await roleRepository.BeginTransaction();
        try
        {
            foreach (var item in permissionIDs)
            {
                bool result = await roleRepository.DeletePermission(roleID, item);
                if (!result)
                {
                    await roleRepository.RollbackTransaction();
                    return false;
                }
            }
            await roleRepository.CommitTransaction();
            return true;
        }
        catch (Exception ex)
        {
            await roleRepository.RollbackTransaction();
            throw new Exception(ex.Message);
        }
    }

    
}
