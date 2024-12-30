using System.ComponentModel.DataAnnotations;
namespace Arti.Client.Models
{
    public class Balcony
    {
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "لا يمكنك ادخال قيمه سالب")]
        public int BalconySize { get; set; }

        [Required]
        [StringLength(100)]
        public string View { get; set; }
    }
}