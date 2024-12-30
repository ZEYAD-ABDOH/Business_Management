using System.ComponentModel.DataAnnotations;
namespace Arti.Client.Models
{
    public class GardenType
    {
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "لا يمكنك ادخال قيمه سالب")]
        public int GardenSize { get; set; }

        [Required]
        [StringLength(500)]
        public string PlantTypes { get; set; }

        [Required]
        public string IrrigationSystem { get; set; }

        [Required]
        public bool Playground { get; set; }

        [Required]
        [StringLength(200)]
        public string SeatingArea { get; set; }
    }
}