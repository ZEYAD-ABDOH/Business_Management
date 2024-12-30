using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectArti.Api.Model
{
    public class TaskArti
    {
        public int Id { get; set; }
       
    
        public string Name { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل وصف  لنوع المهمه او  النشاط الذي  سوف تقوم  به          ")]
        [StringLength(maximumLength: 300, MinimumLength = 20, ErrorMessage = "  يجب عليك ادخل وصف عن المهمه   و يجب ان لا يقل على الاقل  20 ولايزيد عن   300 كلمة")]
        public string Description { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  تاريخ بداية  المهمه . ")]
        [DataType(DataType.Date)]
        public DateTime startTask { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  تاريخ الانتهاء  المهمه . ")]
        [DataType(DataType.Date)]
        public DateTime endTask { get; set; }
     
       
        public int CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public Company? Company { get; set; }

        public int? CraftsmanID { get; set; }
        [ForeignKey("CraftsmanID")]
        public Craftsman? craftsman { get; set; }

        public int? EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public Employee? employee { get; set; }


    }
}
