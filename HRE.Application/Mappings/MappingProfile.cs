﻿using AutoMapper;
using HRE.Application.DTOs.Area;
using HRE.Application.DTOs.Gift;
using HRE.Application.DTOs.Location;
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

        // Location
        CreateMap<LocationDTO,Location>();

        // Area
        CreateMap<AreaDTO, Area>();

        // Gift
        CreateMap<GiftDTO,Gift>();
    }
}
