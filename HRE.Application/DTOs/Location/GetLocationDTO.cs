namespace HRE.Application.DTOs.Location;

public class GetLocationDTO
{
    public string Region { get; set; } = default!;

    public List<DeviceInfo> Devices { get; set; } = default!;
}

public class DeviceInfo
{
    public string DeviceCode { get; set; } = default!;

    public string TypeDevice { get; set; } = default!;

    public DateTime DateAddedToLocation { get; set; }

    public bool Status { get; set; }
}

