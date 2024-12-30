
using System.ComponentModel.DataAnnotations.Schema;


namespace Arti.Client.Models
{
    public class Craftsman : Person
    {
        
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public Company? Company { get; set; }


    }
}
