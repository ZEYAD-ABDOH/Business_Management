﻿using System.ComponentModel.DataAnnotations;
namespace Arti.Client.Models
{
    public class Garage
    {
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "لا يمكنك ادخال قيمه سالب")]
        public int GarageSize { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "لا يمكنك ادخال قيمه سالب")]
        public int Capacity { get; set; }
    }
}