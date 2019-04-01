using System;

namespace RESTService.ViewModels
{
    public class CreateBookingViewModel
    {
        public long RoomId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
