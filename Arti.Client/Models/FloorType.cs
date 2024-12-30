using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Arti.Client.Models
{
    public class FloorType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "يجب عليك ادخل اسم نوع طابق  ولايزيد عن 50 كلمة ")]
        public string? TypeName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "يجب عليك ادخل عدد طابق")]
        public int? FloorNumber { get; set; }

        [StringLength(100, ErrorMessage = "وصف عن نوع الجديد بحيث لا يزيد عن 100 كلمة")]
        public string? Description { get; set; }
        [Required]
        public bool? IsResidential { get; set; } // تحديد ما إذا كان الطابق سكني أم لا
        [Required]
        public bool? IsCommercial { get; set; } // تحديد ما إذا كان الطابق تجاري أم لا




        public int? CommercialTypeId { get; set; }
        [ForeignKey("CommercialTypeId")]
        public CommercialType? commercialType { get; set; }
        public int? ParkingId { get; set; }
        [ForeignKey("ParkingId")]
        public Parking? parking { get; set; }
        public int? GardenTypeId { get; set; }
        [ForeignKey("GardenTypeId")]
        public GardenType? gardenType { get; set; }
        public int? SwimmingPoolTId { get; set; }
        [ForeignKey("SwimmingPoolTId")]
        public SwimmingPoolT? swimmingPoolT { get; set; }
        public int? GarageId { get; set; }
        [ForeignKey("GarageId")]
        public Garage? garage { get; set; }
        public int? BalconyId { get; set; }
        [ForeignKey("BalconyId")]
        public Balcony? balcony { get; set; }
        public int? GymTopId { get; set; }
        [ForeignKey("GymTopId")]
        public GymTop? gymTop { get; set; }
        public int? MeetingRoomId { get; set; }
        [ForeignKey("MeetingRoomId")]
        public MeetingRoom? meetingRoom { get; set; }
        public int? RecreationalAreaId { get; set; }
        [ForeignKey("RecreationalAreaId")]
        public RecreationalArea? recreationalArea { get; set; }


    }
}