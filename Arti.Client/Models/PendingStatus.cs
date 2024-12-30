using System.ComponentModel.DataAnnotations;
namespace Arti.Client.Models
{
    public class PendingStatus
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخل  تاريخ تعليق الحالة ")]
        [DataType(DataType.Date)]
        public DateTime PendingSince { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  تاريخ المتوقع لإتمام الصفقة أو الإيجار ")]
        [DataType(DataType.Date)]
        public DateTime ExpectedCloseDate { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  سبب تعليق الحالة. ")]
        [StringLength(200)]
        public string ReasonForPending { get; set; }
    }

}