
using AutoMapper;
using HRE.Application.DTOs.Location;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HRE.Application.Services;

public class LocationService : ILocationService
{
    private readonly IBaseRepository<Location> locationRepository;
    private readonly IMapper mapper;
    public LocationService(IBaseRepository<Location> locationRepository, IMapper mapper)
    {
        this.locationRepository = locationRepository;
        this.mapper = mapper;
    }

    public async Task<Location?> Create(LocationDTO entity)
    {
        var location = mapper.Map<Location>(entity);
        await locationRepository.AddAsync(location);
        var result = await locationRepository.SaveChangesAsync();
        return result>0 ? location:null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await locationRepository.GetByIdAsync(id);
        if (entityToDelete == null) return false;
        locationRepository.Delete(entityToDelete);
        return await locationRepository.SaveChangesAsync()>0;
    }

    public async Task<bool> Update(int id,LocationDTO entity)
    {
        var entityToUpdate = await locationRepository.GetByIdAsync(id);
        if(entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        locationRepository.Update(entityToUpdate);
        return await locationRepository.SaveChangesAsync() > 0;
    }

    public async Task<GetLocationsDTO> Get()
    {
        var data = locationRepository.AsQueryable();

        // Đếm các Campaign có StartDate nhỏ hơn hiện tại và EndDate lớn hơn hoặc bằng hiện tại
        var count = await data
            .Where(x => x.Campaigns.Any(c => c.StartDate < DateTime.Now && c.EndDate >= DateTime.Now))
            .CountAsync();

        // Lấy thông tin chi tiết các Location
        var locationDetails = await data
            .Select(location => new LocationInfo
            {
                Region = location.Area!=null? location.Area.Name:string.Empty,
                DateAdded = location.DateAdded,
                // Tính số lượng thiết bị
                OperationalDevicesCount = location.Campaigns
                    .Sum(c => c.RobotCampaigns.Count() + c.MachineCampaigns.Count())
            })
            .ToListAsync();

        var locations = new GetLocationsDTO
        {
            TotalLocationsCreated = await data.CountAsync(),
            CampaignLocationsCount = count,
            Locations = locationDetails
        };

        return locations;
    }


    public async Task<GetLocationDTO?> GetByID(int id)
    {
        // Lấy dữ liệu Location từ repository
        var data = locationRepository.AsQueryable().Where(x => x.Id == id);

        // Kiểm tra nếu không có dữ liệu
        var locationData = await data.FirstOrDefaultAsync();
        if (locationData == null) return null;

        // Tạo danh sách thiết bị
        var devicesQuery = locationData.Campaigns
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
                locationData.Campaigns.SelectMany(campaign => campaign.MachineCampaigns)
                .Select(device => new DeviceInfo
                {
                    DeviceCode = device.Machine.MachineCode,       // Mã thiết bị máy tái chế
                    TypeDevice = "Recycling Machine",              // Loại thiết bị là Máy tái chế
                    DateAddedToLocation = device.CreatedDate,      // Ngày thiết bị được thêm vào địa điểm
                    Status = device.Machine.Status                  // Trạng thái kết nối của máy tái chế
                })
            )
            .OrderByDescending(x => x.DateAddedToLocation);  // Sắp xếp theo ngày thêm vào địa điểm

        // Tạo DTO trả về
        var location = new GetLocationDTO
        {
            Region = locationData.Area?.Name ?? string.Empty,
            Devices = devicesQuery.ToList() // Chuyển query thành list sau khi lấy từ cơ sở dữ liệu
        };

        return location;
    }

}
