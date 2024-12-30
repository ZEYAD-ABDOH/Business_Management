
using Arti.Client.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectArti.Api.Model
{
    public class Person
    {
        public int Id { get; set; }
        
        public string? Images { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل الاسم  ")]
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
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = " يجب عليك ادخل  العنوان بشكل كامل")]
        public string Address { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  رقم الموبايل ")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  مهاراتك  ")]
        public string Skill { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  المسمى الوظيفي ")]
        public string Position { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  تاريخ الميلاد ")]
        [DataType(DataType.Date)]
        public DateTime BirtDate { get; set; }
        [Required(ErrorMessage = "   يجب عليك ادخل  سنوات الخبرة ")]
        [Range(2, 15, ErrorMessage = "  يجب ان تكون الخبرة لا تقل عن سنتين")]
        public double YearsOfExperience { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخل الجنس")]
        [JsonConverter(typeof(EnumToStringConverter<Gender>))]
        [RegularExpression(@"^(Male|Femle)$", ErrorMessage = "(Male|Femle) يجب عليك ادخل الجنس ")]

        public Gender Gender { get; set; }
    }

  
}
