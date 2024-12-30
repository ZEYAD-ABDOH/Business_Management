using System.ComponentModel.DataAnnotations;

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
    public double MonthlyRent { get; set; }

}

