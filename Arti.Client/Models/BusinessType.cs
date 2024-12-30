using System.ComponentModel.DataAnnotations;

namespace Arti.Client.Models
{
    public class BusinessType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخل اسم  العمل او النشاط  الذي  تقوم به  الشركة      ")]
        [StringLength(maximumLength: 50, MinimumLength = 12, ErrorMessage = "يجب ادخال  الاسم العمل او النشاط  الذي  تقوم به  الشركة  و يجب ان لا يقل على الاقل  12 ولايزيد عن 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل وصف  لنوع العمل او  النشاط الذي  تقوم به  الشركة مثلاً(عقارات , خدمات، تجارة، إلخ )         ")]
        [StringLength(maximumLength: 300, MinimumLength = 20, ErrorMessage = "  يجب ادخال الاسم  و يجب ان لا يقل على الاقل  20 ولايزيد عن   300 كلمة")]
        public string Description { get; set; }
        [Required(ErrorMessage = " يجب عليك ادخل  قطاع العمل     ")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "  يجب ادخال (مثلاً، خدمات، تجارة، زراعة، تصنيع).")]
        public string Industry { get; set; }


    }
}
