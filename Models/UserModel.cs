using System.ComponentModel.DataAnnotations;

namespace VehicleRentalSystem.Models;

public class UserModel
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [EmailAddress]
    public string UserEmail { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 8)]
    public string UserPassword { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string UserCountry { get; set; }

    [Required]
    public string UserCity { get; set; }

       
    public virtual ICollection<RentalModel> Rentals { get; set; }
}