
using AutoMapper;
using HRE.Application.DTOs.Location;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using System.Linq;

namespace HRE.Application.Services;

public class LocationService : ILocationService
{
    private readonly ILocationRepository locationRepository;
    private readonly IMapper mapper;
    public LocationService(ILocationRepository locationRepository, IMapper mapper)
    {
        this.locationRepository = locationRepository;
        this.mapper = mapper;
    }

    public async Task<Location?> Create(LocationDTO entity)
    {
        var result = await locationRepository.Create(mapper.Map<Location>(entity));
        return result;
    }

    public async Task<bool> Delete(int id)
    {
        return await locationRepository.Delete(id);
    }

    public async Task<bool> Update(int id,LocationDTO entity)
    {
        var entityToUpdate = await locationRepository.GetByID(id);
        if(entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        return await locationRepository.Update(entityToUpdate);
    }

    public async Task<GetLocationsDTO> Get()
    {
        var data = await locationRepository.GetAll();

        var count = data.Count(x => x.Campaigns.Any(c => c.StartDate < DateTime.Now && c.EndDate >= DateTime.Now));

        var locationDetails = data.Select(location => {

            var countRobot = location.Campaigns.SelectMany(c => c.RobotCampaigns).Count();
            var countMachine = location.Campaigns.SelectMany(c => c.MachineCampaigns).Count();
            return new LocationInfo
            {
                Region = location.Area?.Name ?? string.Empty,
                DateAdded = location.DateAdded,
                OperationalDevicesCount = countRobot + countMachine
            };
        }).ToList();
        var locations = new GetLocationsDTO
        {
            TotalLocationsCreated = data.Count(),
            CampaignLocationsCount = count,
            Locations = locationDetails
        };

        return locations;
    }

    public async Task<GetLocationDTO?> GetByID(int id)
    {
        var data = await locationRepository.GetByID(id);
        if (data == null) return null;

        var devices = data.Campaigns
            // Kết hợp các thiết bị Robot
            .SelectMany(campaign => campaign.RobotCampaigns
                .Select(device => new DeviceInfo
                {
                    DeviceCode = device.Robot.RobotCode,           // Mã thiết bị robot
                    TypeDevice = device.Robot.RobotType,           // Loại thiết bị là Robot
                    DateAddedToLocation = device.CreatedDate,      // Ngày thiết bị được thêm vào địa điểm
                    Status = device.Robot.Status                    // Trạng thái kết nối của robot
                })
            )
            // Kết hợp với các thiết bị Máy tái chế
            .Concat(
                data.Campaigns.SelectMany(campaign => campaign.MachineCampaigns)
                .Select(device => new DeviceInfo
                {
                    DeviceCode = device.Machine.MachineCode,       // Mã thiết bị máy tái chế
                    TypeDevice = "Recycling Machine",              // Loại thiết bị là Máy tái chế
                    DateAddedToLocation = device.CreatedDate,      // Ngày thiết bị được thêm vào địa điểm
                    Status = device.Machine.Status                  // Trạng thái kết nối của máy tái chế
                })
            )
            .OrderByDescending(x => x.DateAddedToLocation)  // Sắp xếp theo ngày thêm vào địa điểm
            .ToList();

        var location = new GetLocationDTO
        {
            Region = data.Area?.Name ?? string.Empty, 
            Devices = devices
        };

        return location;
    }

}
