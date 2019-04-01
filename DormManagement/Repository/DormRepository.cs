using Model;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DormRepository : IDormRepository
    {
        private readonly DormManagementContext context;

        public DormRepository(DormManagementContext context)
        {
            this.context = context;
        }

        public List<RoomEntity> GetAvailableRooms(DateTime dateFrom, DateTime dateTo)
        {
            IQueryable<BookingEntity> bookedEntities = GetBookedData(dateFrom, dateTo);

            IQueryable<RoomEntity> availableRooms = context.Rooms
                                        .Where(room => !bookedEntities.Any(booking => booking.RoomId == room.Id));

            return availableRooms.ToList();
        }

        public bool IsRoomAvailable(long roomId, DateTime dateFrom, DateTime dateTo)
        {
            IQueryable<BookingEntity> bookedEntities = GetBookedData(dateFrom, dateTo);

            return !bookedEntities.Any(x => x.RoomId == roomId);
        }

        public void CreateBooking(long roomId, DateTime dateFrom, DateTime dateTo)
        {
            BookingEntity entity = new BookingEntity()
            {
                RoomId = roomId,
                StartDate = dateFrom,
                EndDate = dateTo,
                UsedPalces = 1,
                //Gender 
            };

            context.Bookings.Add(entity);
            context.SaveChanges();
        }

        private IQueryable<BookingEntity> GetBookedData(DateTime dateFrom, DateTime dateTo)
        {
            return from booking in context.Bookings
                   where
                     ((dateFrom >= booking.StartDate) && (dateFrom <= booking.EndDate)) ||
                     ((dateTo >= booking.StartDate) && (dateTo <= booking.EndDate)) ||
                     ((dateFrom <= booking.StartDate) &&
                                  (dateTo >= booking.StartDate) && (dateTo <= booking.EndDate)) ||
                     ((dateFrom >= booking.StartDate) &&
                                  (dateFrom <= booking.EndDate) && (dateTo >= booking.EndDate)) ||
                     ((dateFrom <= booking.StartDate) && (dateTo >= booking.EndDate))
                   select booking;
        }
    }
}
