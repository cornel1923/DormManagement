using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IDormBusinessLogic
    {
        List<RoomDTO> GetRooms(DateTime? dateFrom, DateTime? dateTo);

        void CreateBooking(CreateBookingModel model);
    }
}
