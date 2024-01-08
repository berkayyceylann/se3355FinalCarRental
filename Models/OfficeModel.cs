using System.ComponentModel.DataAnnotations;

namespace VehicleRentalSystem.Models;

public class OfficeModel
{
    [Key]
    public int OfficeId { get; set; }

    [Required]
    public string OfficeName { get; set; }

    [Required]
    public string OfficeAddress { get; set; }

    [Required]
    public string OfficeCity { get; set; }

    [Required]
    public string OfficeCountry { get; set; }

    [Required]
    public double Latitude { get; set; }

    [Required]
    public double Longitude { get; set; }
}