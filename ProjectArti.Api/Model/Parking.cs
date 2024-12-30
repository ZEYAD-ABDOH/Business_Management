using System.ComponentModel.DataAnnotations;

public class Parking
{
    public int Id { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "لا يمكنك ادخال قيمه سالب")]
    public int TotalSpots { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "لا يمكنك ادخال قيمه سالب")]
    public int CoveredSpots { get; set; }
}
