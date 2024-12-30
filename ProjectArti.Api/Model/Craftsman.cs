using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectArti.Api.Model
{
    public class Craftsman : Person
    {
        
        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public Company? Company { get; set; }


    }
}
