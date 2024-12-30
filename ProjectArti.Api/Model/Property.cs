
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectArti.Api.Model
{
    public class Property
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "يجب عليك ادخل حجم العقار  ")]
        [StringLength(100)]
        public string UnitSize { get; set; }

        [Required(ErrorMessage = "   يجب عليك ادخل اسم العقار  ويجب ان يكون فريد  ")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "   يجب عليك ادخل عنوان العقار   ")]
        [StringLength(100)]
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int PropertyTypeId { get; set; }
        [ForeignKey("PropertyTypeId")]
        public PropertyType?  propertyType { get; set; }

        public int PropertyStatusId { get; set; }
        [ForeignKey("PropertyStatusId")]
        public PropertyStatus? PropertyStatus { get; set; }

        public int CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public Company? Company { get; set; }
    }
}
