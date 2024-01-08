using System.ComponentModel.DataAnnotations;

namespace VehicleRentalSystem.Models;

public class LoginModel
{
    [Required]
    [EmailAddress]
    public string UserEmail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string UserPassword { get; set; }
}