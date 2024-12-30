using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arti.Client.Models
{
    public class Company 
    {

        public int Id { get; set; }
       
        [Required(ErrorMessage = "يجب عليك ادخل اسم الشركة  ")]
        [StringLength(maximumLength: 50, MinimumLength = 12, ErrorMessage = "يجب ادخال الاسم  و يجب ان لا يقل على الاقل  12 ولايزيد عن 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل الوصف  ")]
        [StringLength(maximumLength: 200, MinimumLength = 12, ErrorMessage = "   يجب ان لا يقل على الاقل  12 ولايزيد عن 200 كلمة")]
        public string Description { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  الايميل ")]
        [DataType(DataType.EmailAddress, ErrorMessage = "الايميل غير صحيح ")]
        [RegularExpression(@"\w+@\w+.\w+", ErrorMessage = "الايميل غير صحيح")]
        public string Email { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  العنوان بشكل كامل ")]
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "يجب ادخال يجب عليك ادخل  العنوان بشكل كامل")]
        public string Address { get; set; }
        [Required(ErrorMessage =  "  يجب عليك ادخل  رقم الموبايل الخاص بشركة")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  اسم المالك هذي الشركة  ")]
        public string Author { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  تاريخ الانشاء هذي الشركة ")]
        [DataType(DataType.Date)]
        public DateTime EstablishedDate { get; set; }
        public int BusinessTypeID { get; set; }
        [ForeignKey("BusinessTypeID ")]
        public  BusinessType? businessType { get; set; }
      






    }
}
