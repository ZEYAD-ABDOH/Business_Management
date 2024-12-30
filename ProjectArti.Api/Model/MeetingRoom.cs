using System.ComponentModel.DataAnnotations;

public class MeetingRoom
{
    public int Id { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "لا يمكنك ادخال قيمه سالب")]
    public int RoomSize { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "لا يمكنك ادخال قيمه سالب")]
    public int Capacity { get; set; }
}
