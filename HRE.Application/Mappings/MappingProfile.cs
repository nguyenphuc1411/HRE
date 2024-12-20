﻿using AutoMapper;
using HRE.Application.DTOs.Area;
using HRE.Application.DTOs.Campaign;
using HRE.Application.DTOs.CampaignRule;
using HRE.Application.DTOs.Gift;
using HRE.Application.DTOs.GiftRedemption;
using HRE.Application.DTOs.GiftRule;
using HRE.Application.DTOs.Location;
using HRE.Application.DTOs.Permission;
using HRE.Application.DTOs.RecyclingMachine;
using HRE.Application.DTOs.Reward;
using HRE.Application.DTOs.Robot;
using HRE.Application.DTOs.Role;
using HRE.Application.DTOs.User;
using HRE.Application.DTOs.UserInteraction;
using HRE.Application.DTOs.UserPoint;
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
        CreateMap<GiftInRuleDTO, GiftInRule>();


        // Permission
        CreateMap<PermissionDTO,Permission>();
        CreateMap<GroupDTO, PermissionGroup>();

        // User 
        CreateMap<UserDTO,User>();

        // Campaign 
        CreateMap<CampaignDTO,Campaign>();

        CreateMap<CampaignGiftDTO, CampaignGift>();

        // Campaign Rule
        CreateMap<CampaignRuleDTO,CampaignRule>();

        // User Interaction
        CreateMap<StartUserInteractionDTO, UserInteraction>();

        // Redemption
        CreateMap<RedemptionDTO,GiftRedemption>();
    }
}
