

using ProjectArti.Api.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Arti.Client.Models
{
    public class JobApplication
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل   المنصب أو الوظيفة المتقدم لها   ،      ")]
        [StringLength(maximumLength: 50, MinimumLength = 20, ErrorMessage = "  يجب ادخل  المنصب أو الوظيفة المتقدم لها و يجب ان لا يقل على الاقل  20  كلمة")]
        public string Position { get; set; } // المنصب أو الوظيفة المتقدم لها

        [Required(ErrorMessage = "يجب عليك ادخل وصف  لنوع العمل او  النشاط الذي  تقوم به  الشركة مثلاً(عقارات , خدمات، تجارة، إلخ )         ")]
        [StringLength(maximumLength: 300, MinimumLength = 20, ErrorMessage = "  يجب ادخال وصف  و يجب ان لا يقل على الاقل  20 ولايزيد عن   300 كلمة")]
        public string Description { get; set; }
        [Url]
        [Required(ErrorMessage = "يجب عليك ارفاق السيرة الذاتية    ")]
        public string ResumeCV { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  تاريخ التقديم . ")]
        [DataType(DataType.Date)]
        public DateTime ApplicationDate { get; set; }
        public StatuApplicant StatuApplicant { get; set; }
        public int CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public Company? Company { get; set; }



    }


}
