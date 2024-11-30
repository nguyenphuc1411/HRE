
using HRE.Application.DTOs.User;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IUserService
{
    Task<User?> Create(UserDTO entity);

    Task<bool> Update(int id,UserDTO entity);

    Task<bool> Delete(int id);
}
