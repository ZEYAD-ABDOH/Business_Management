
using Arti.Client.Models;
using ProjectArti.Api.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectArti.Api.Model
{
    public class RequestClient
    {
        public int id { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخل  تاريخ   الطلبات . ")]
        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }
        public StatusRequest statusRequest { get; set; }
        [Required(ErrorMessage = "يجب عليك ادخل  نوع الخدمة المطلوبة  . ")]
        [StringLength(100)]
        public string ServiceType { get; set; } 
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public Client? client { get; set; }

    }
}
