namespace HRE.Application.DTOs.Location;

public class GetLocationsDTO
{
    public int TotalLocationsCreated { get; set; }
    public int CampaignLocationsCount { get; set; }

    public List<LocationInfo> Locations { get; set; } = new List<LocationInfo>();
}
public class LocationInfo
{
    public string Region { get; set; } = default!;
    public DateTime DateAdded { get; set; }
    public int OperationalDevicesCount { get; set; }
}
