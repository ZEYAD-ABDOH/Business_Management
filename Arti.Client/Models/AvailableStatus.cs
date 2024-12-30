using System.ComponentModel.DataAnnotations;

namespace Arti.Client.Models
{
    public class AvailableStatus
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخل  تاريخ إدراج العقار. ")]
        [DataType(DataType.Date)]
        public DateTime DateListed { get; set; }
        [Required]
        public double Price { get; set; }
        [StringLength(100)]
        [Required]
        public string SpecialOffers { get; set; }
    }

}