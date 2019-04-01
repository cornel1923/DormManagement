using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.DTOs
{
    public class CreateBookingModel
    {
        public long RoomId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
