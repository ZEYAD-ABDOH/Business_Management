
using System.ComponentModel.DataAnnotations;


namespace Arti.Client.Models
{
    public class BaseRating
    {

        public int Id { get; set; }

        
        [Range(1, 5, ErrorMessage = "(تقييم الجودة (1-5")]
        public double? Quality { get; set; }  // (تقييم الجودة (1-5)
        [Range(1, 5, ErrorMessage = "(تقييم الالتزام بالوقت (1-5")]

        public double? Timeliness { get; set; }  // تقييم الالتزام بالوقت (1-5)
        [Range(1, 5, ErrorMessage = "(تقييم الاحترافية  (1-5")]

        public double? Professionalism { get; set; }  // تقييم الاحترافية (1-5)
        [Range(1, 5, ErrorMessage = "(تقييم التواصل  (1-5")]

        public double? Communication { get; set; }  // تقييم التواصل (1-5)
        [Range(1, 5, ErrorMessage = "(الرضا العام  (1-5")]

        public double? OverallSatisfaction { get; set; }  // الرضا العام (1-5)

        [StringLength(maximumLength: 150, MinimumLength = 6, ErrorMessage = "تعليقات النصية لا يزيد عن 150 كلمة  ")]

        public string? Comments { get; set; } // تعليقات النصية



    }
}
