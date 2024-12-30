


using ProjectArti.Api.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Arti.Client.Models
{
    public class Applicant : Person
    {
      
        [Required(ErrorMessage = "يجب عليك ارفاق السيرة الذاتية    ")]
        public string ResumeCV { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  تاريخ التقديم ")]
        [DataType(DataType.Date)]
        public DateTime ApplicationDate { get; set; }
        [Required(ErrorMessage = " يجب عليك اختيار حالة التقديم    ")]
     
        public int CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public Company? Company { get; set; }
        public int JobApplicationID { get; set; }
        [ForeignKey("JobApplicationID")]
        public Employee? jobApplication { get; set; }


    }


}
