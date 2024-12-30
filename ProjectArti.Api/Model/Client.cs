using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjectArti.Api.Model
{
    public class Client : Person
    {

        [Required(ErrorMessage = "يجب عليك ادخل  كلمة السر ")]
        [RegularExpression(@"^(?=.*\d)(?=.*[\W_])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "كلمة السر يجب ان تحتوي على حروف و ارقام و رموز ")]
        public string Password { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل الصلاحيات ")]
        [Range(1, 5, ErrorMessage = "صلاحة المستخدم يجب ان يكون بين 1الى5 ")]
        public int Role { get; set; }
        public int? CraftsmanID { get; set; }
        [ForeignKey("CraftsmanID")]
        public Craftsman? craftsman { get; set; }
        public int? PropertyID { get; set; }
        [ForeignKey("PropertyID")]
        public Property? property { get; set; }
        public int? BaseRatingID { get; set; }
        [ForeignKey("BaseRatingID")]
        public BaseRating? baseRating { get; set; }
        public int? TaskID { get; set; }
        [ForeignKey("TaskID")]
        public TaskArti? task { get; set; }



    }
}
