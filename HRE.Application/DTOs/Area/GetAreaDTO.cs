namespace HRE.Application.DTOs.Area;

public class GetAreaDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

    public int TotalLocationOfArea { get; set; } = 0;
}
