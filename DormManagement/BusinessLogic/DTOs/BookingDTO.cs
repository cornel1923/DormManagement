using System;

namespace BusinessLogic.DTOs
{
    public class BookingDTO
    {
        public long Id { get; set; }

        public long RoomId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public short UsedPalces { get; set; }

        public GenderEnum Gender { get; set; }
    }
}
