namespace CarApi.Domain.Models;

public class Car
{
    public CarNumber CarNumber { get; set; }
    public string CarType { get; set; }
    public DateTime ManufactureDate { get; set; }
}