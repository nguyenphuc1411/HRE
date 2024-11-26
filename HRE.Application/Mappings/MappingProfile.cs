using AutoMapper;
using HRE.Application.DTOs.RecyclingMachine;
using HRE.Application.DTOs.Robot;
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
    }
}
