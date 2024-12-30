using System.ComponentModel.DataAnnotations;

namespace Arti.Client.Models
{
    public class GymTop
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Equipment { get; set; }

        [Required]
        public string OpeningHours { get; set; }

        [Required]
        public bool PersonalTraining { get; set; }

        [Required]
        [StringLength(500)]
        public string ClassesOffered { get; set; }
    }
}