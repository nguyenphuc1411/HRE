using AutoMapper;
using HRE.Application.DTOs.Area;
using HRE.Application.DTOs.Gift;
using HRE.Application.DTOs.GiftRule;
using HRE.Application.DTOs.Location;
using HRE.Application.DTOs.Permission;
using HRE.Application.DTOs.RecyclingMachine;
using HRE.Application.DTOs.Robot;
using HRE.Application.DTOs.Role;
using HRE.Application.DTOs.User;
using HRE.Domain.Entities;

namespace HRE.Application.Mappings;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        // Robot
        CreateMap<CreateRobotDTO, Robot>();
        CreateMap<UpdateRobotDTO, Robot>();       

        CreateMap<Robot,GetRobotDTO>();

        // Recycling Machine
        CreateMap<CreateRMDTO,RecyclingMachine>();
        CreateMap<UpdateRMDTO, RecyclingMachine>();
        CreateMap<RecyclingMachine,GetRMDTO>();

        // Location
        CreateMap<LocationDTO,Location>();

        // Area
        CreateMap<AreaDTO, Area>();

        // Gift
        CreateMap<GiftDTO,Gift>();

        // Role
        CreateMap<RoleDTO,Role>();

        // Rule
        CreateMap<GiftRuleDTO,GiftRule>();

        // Permission
        CreateMap<PermissionDTO,Permission>();
        CreateMap<GroupDTO, PermissionGroup>();

        // User 
        CreateMap<UserDTO,User>();
    }
}
