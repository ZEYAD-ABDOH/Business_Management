using System.ComponentModel.DataAnnotations;

public class SwimmingPoolT
{
    public int Id { get; set; }

    [Required]
    public int PoolSize { get; set; }

    [Required]
    public int Depth { get; set; }
}
