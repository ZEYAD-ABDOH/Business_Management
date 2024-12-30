using System.ComponentModel.DataAnnotations;

namespace ProjectArti.Api.Model
{
    public class Userlogin
    {


       
            [Required(ErrorMessage = "يجب ادخال الاسم ")]
            public string Name { get; set; }
            [Required(ErrorMessage = "يجب ادخل كلمة المرور")]
            public string Password { get; set; }
       
    }
}
