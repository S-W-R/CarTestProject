using AutoMapper;
using CarApi.Domain.Models;
using CarApi.DTO;
using CarApi.Infrastructure.Models;
using CarApi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Controllers;

[ApiController]
[Route("api/v1/trash")]
public class CarApiController : ControllerBase
{
    private readonly ILogger<CarApiController> _logger;
    private readonly CarContext _carContext;
    private readonly IMapper _mapper;

    public CarApiController(ILogger<CarApiController> logger, CarContext carContext, IMapper mapper)
    {
        _logger = logger;
        _carContext = carContext;
        _mapper = mapper;
    }

    [HttpGet("getCar/{carNumber}")]
    public async Task<IActionResult> GetCar(string carNumber)
    {
        _logger.Log(LogLevel.Information, "Car number was: {carNumber}", carNumber);
        var carDb = await _carContext.Cars.FindAsync(carNumber);
        if (carDb is null)
            return NotFound();
        var carDto = _mapper.Map<CarDTO>(_mapper.Map<Car>(carDb));
        return Ok(carDto);
    }

    [HttpGet("getCars")]
    public async Task<IActionResult> GetCars()
    {
        _logger.Log(LogLevel.Information, "All cars request");
        var carDbs = await _carContext.Cars.ToArrayAsync();
        return Ok(carDbs.Select(x => _mapper.Map<CarDTO>(_mapper.Map<Car>(x))).ToArray());
    }

    [HttpPut("addCar")]
    public async Task<IActionResult> AddCar(CarDTO carDto)
    {
        await _carContext.Cars.AddAsync(_mapper.Map<CarDbEntity>(_mapper.Map<Car>(carDto)));
        await _carContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("deleteCar/{carNumber}")]
    public async Task<IActionResult> DeleteCar(string carNumber)
    {
        var carDb = await _carContext.Cars.FindAsync(carNumber);
        if (carDb is null)
            return NotFound();
        _carContext.Remove(carDb);
        await _carContext.SaveChangesAsync();
        return Ok();
    }
}