using Model.Models;
using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IDormRepository
    {
        List<RoomEntity> GetAvailableRooms(DateTime dateFrom, DateTime dateTo);

        bool IsRoomAvailable(long roomId, DateTime dateFrom, DateTime dateTo);

        void CreateBooking(long roomId, DateTime dateFrom, DateTime dateTo);
    }
}
