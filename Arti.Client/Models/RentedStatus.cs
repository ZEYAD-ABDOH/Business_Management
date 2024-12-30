using System.ComponentModel.DataAnnotations;
namespace Arti.Client.Models
{
    public class RentedStatus
    {
        public int Id { get; set; }
        public string NameStatus { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  تاريخ بداية الإيجار. ")]
        [DataType(DataType.Date)]
        public DateTime RentalStartDate { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل تاريخ نهاية الإيجار. ")]
        [DataType(DataType.Date)]
        public DateTime RentalEndDate { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل الإيجار الشهري. ")]

        [Range(0, double.MaxValue, ErrorMessage = "لا يمكن ان تدخل عدد سالب في الإيجار الشهري ")]
        public double MonthlyRent { get; set; }

    }

}