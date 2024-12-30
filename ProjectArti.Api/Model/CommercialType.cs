using System.ComponentModel.DataAnnotations;

public class CommercialType
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(100)]
    public string Description { get; set; }
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "لا يمكنك ادخال قيمه سالب")]
    public int OfficeSpaces { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "لا يمكنك ادخال قيمه سالب")]
    public int RetailSpaces { get; set; }
}
