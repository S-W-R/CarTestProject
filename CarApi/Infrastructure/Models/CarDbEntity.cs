namespace CarApi.Infrastructure.Models;

public class CarDbEntity
{
    public string Number { get; set; }
    public int RegionCode { get; set; }
    public string CarType { get; set; }
    public DateTime ManufactureDate { get; set; }
}