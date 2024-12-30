using System.ComponentModel.DataAnnotations;

public class RecreationalArea
{
    public int Id { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "لا يمكنك ادخال قيمه سالب")]
    public int AreaSize { get; set; }

    [Required]
    [StringLength(1000)]
    public string TypesOfActivities { get; set; }

    [Required]
    public bool Playground { get; set; }

    [Required]
    [StringLength(200)]
    public string PicnicArea { get; set; }
}
