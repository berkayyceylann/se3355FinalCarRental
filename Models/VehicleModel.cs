using System.ComponentModel.DataAnnotations;

namespace VehicleRentalSystem.Models;

public class VehicleModel
{
    [Key]
    public int VehicleId { get; set; }

    [Required]
    public string VehicleBrand { get; set; }

    [Required]
    public  string Model { get; set; }

    [Required]
    public string VehicleTransmission { get; set; }

    [Required]
    public decimal VehiclePrice { get; set; }

    [Required]
    public int VehicleMileage { get; set; }

    [Required]
    public decimal VehicleDeposit { get; set; }

    [Required]
    public int VehicleYear { get; set; }

    public string VehicleImageUrl { get; set; }

    public virtual ICollection<RentalModel> VehicleRentals { get; set; }
}