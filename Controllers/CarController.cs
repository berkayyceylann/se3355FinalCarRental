using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleRentalSystem.Data;

public class CarController : Controller
{
    private readonly CarRentalContext _context;

    public CarController(CarRentalContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var vehicles = await _context.Vehicles.ToListAsync();
        return View(vehicles);
    }
}