using System.ComponentModel.DataAnnotations;

namespace Arti.Client.Models;
public class UnderRenovationStatus
{
    public int Id { get; set; }
    [Required(ErrorMessage = "يجب عليك ادخل  تاريخ بداية  التجديد . ")]
    [DataType(DataType.Date)]
    public DateTime RenovationStartDate { get; set; }
    [Required(ErrorMessage = "يجب عليك ادخل  تاريخ المتوقع لإكمال التجديد.")]
    [DataType(DataType.Date)]
    public DateTime ExpectedCompletionDate { get; set; }
}

