using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arti.Client.Models
{
    public class PropertyType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "   يجب عليك ادخل   وصف  للعقار       ")]
        [StringLength(200)]
        public string Description { get; set; }  // وصف للشقة
        [Required(ErrorMessage = "   يجب عليك ادخل   سعر  للعقار       ")]
        [Range(0, double.MaxValue, ErrorMessage = "لا يمكن ان تدخل عدد سالب في عدد الطابق ")]
        public double Price { get; set; }  // سعر الشقة
        [Required(ErrorMessage = "   يجب عليك ادخل   عنوان  للعقار       ")]
        [StringLength(200)]
       
        public string Address { get; set; }  // عنوان الشقة
        [Required(ErrorMessage = "يجب عليك ادخل الطابق العقار")]
 
        [Range(0, int.MaxValue, ErrorMessage = "لا يمكن ان تدخل عدد سالب في عدد الطابق ")]

        public int Floor { get; set; }  // الطابق
        [Required(ErrorMessage = "يجب عليك ادخل رقم الطابق")]
        [Range(0, int.MaxValue, ErrorMessage = "لا يمكن ان تدخل عدد سالب في عدد الحمامات ")]
        public int Bathrooms { get; set; }  // عدد الحمامات
        [Required(ErrorMessage = "يجب عليك ادخل مساحة العقار")]

        [Range(0, int.MaxValue, ErrorMessage = "   لا يمكن ان تدخل عدد سالب في مساحة العقار")]
        public int Size { get; set; }  // مساحة الشقة
        [Required(ErrorMessage = "هل تحتوي على شرفة أم لا")]
        public bool Balcony { get; set; }  // هل تحتوي على شرفة أم لا
        [Required(ErrorMessage = "يجب عليك ادخل سنة البناء")]

        [Range(0, int.MaxValue, ErrorMessage = "   لا يمكن ان تدخل عدد سالب  في سنة البناء")]
        public int YearBuilt { get; set; }  // سنة البناء
        [Url]
        [Required(ErrorMessage = "روابط أو مسارات لصور الشقة")]
        public string ImagesUrl { get; set; }  // روابط أو مسارات لصور الشقة
        public string? Features { get; set; }

       public int FloorTypeId { get; set; }
        [ForeignKey("FloorTypeId")]
       public FloorType? floorType { get; set; }

    }


}
