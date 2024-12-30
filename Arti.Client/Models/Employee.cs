using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Arti.Client.Models
{
    public class Employee : Person
    {

        [Required(ErrorMessage = "يجب عليك ادخل  تاريخ التوظيف ")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "العلامة العشريية يجب ان تكون بين 1الى 2")]
        public double BasicSalary { get; set; }
        public int CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public Company? Company { get; set; }



    }
}
