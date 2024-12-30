
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjectArti.Api.Model
{
    public class Profile : Person
    {
        [Required(ErrorMessage = "يجب عليك ادخل  كلمة السر ")]

        [RegularExpression(@"^(?=.*\d)(?=.*[\W_])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "كلمة السر يجب ان تحتوي على حروف و ارقام و رموز ")]
        public string Password { get; set; }
       
        public DateTime RegistrationDate { get; set; }
        public int? CraftsmanID { get; set; }
        [ForeignKey("CraftsmanID")]
        public Craftsman? craftsman { get; set; }
        public int? EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public Employee? employee { get; set; }
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public Company? Company { get; set; }

        public int? ClientID { get; set; }
        [ForeignKey("ClientID")]
        public Client? client { get; set; }



    }
}
