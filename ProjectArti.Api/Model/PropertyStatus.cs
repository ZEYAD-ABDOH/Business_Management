
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectArti.Api.Model
{
    public class PropertyStatus
    {
        public int Id { get; set; }

        public int? PendingStatusId { get; set; }
        [ForeignKey("PendingStatusId")]
        public PendingStatus? PendingStatus { get; set; }
        public int? RentedStatusId { get; set; }
        [ForeignKey("RentedStatusId")]
        public RentedStatus? RentedStatus { get; set; }
        public int? SoldStatusId { get; set; }
        [ForeignKey("SoldStatusId")]
        public SoldStatus? SoldStatus { get; set; }
        public int? AvailableStatusId { get; set; }
        [ForeignKey("AvailableStatusId")]
        public AvailableStatus? AvailableStatus { get; set; }
        public int? UnderRenovationStatusId { get; set; }
        [ForeignKey("UnderRenovationStatusId")]
        public UnderRenovationStatus? UnderRenovationStatus { get; set; }
    }
}
