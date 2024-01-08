using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleRentalSystem.Models;

public class RentalModel
{
    
    [Key]
    public int RentalId { get; set; }

    [ForeignKey("UserModel")]
    public int UserId { get; set; }

    [ForeignKey("VehicleModel")]
    public int VehicleId { get; set; }

    [Required]
    public DateTime SDate { get; set; }

    [Required]
    public DateTime EDate { get; set; }

    [Required]
    public decimal TotalPrice { get; set; }

    public bool Available { get; set; }

    public virtual UserModel UserModel { get; set; }
    public virtual VehicleModel VehicleModel { get; set; }
}