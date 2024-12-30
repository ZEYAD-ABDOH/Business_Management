using System.ComponentModel.DataAnnotations;
namespace Arti.Client.Models
{
    public class SoldStatus
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل تاريخ بيع العقار. ")]
        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل السعر الذي تم بيع العقار به. ")]

      
        [Range(0, double.MaxValue, ErrorMessage = "لا يمكن ان تدخل عدد سالب في   السعر الذي تم بيع العقار به ")]
        public double SalePrice { get; set; }
    }

}