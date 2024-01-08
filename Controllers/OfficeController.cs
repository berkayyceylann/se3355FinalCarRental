using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleRentalSystem.Data;

public class OfficeController : Controller
{
    private readonly CarRentalContext _context;

    public OfficeController(CarRentalContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var offices = await _context.Offices.ToListAsync();
        return View(offices);
    }
}