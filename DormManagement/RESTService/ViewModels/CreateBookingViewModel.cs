using System;
using System.ComponentModel.DataAnnotations;

namespace RESTService.ViewModels
{
    public class CreateBookingViewModel
    {
        [Required]
        public long RoomId { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }
    }
}
