using System;
using System.Collections.Generic;
using AutoMapper;
using BusinessLogic.DTOs;
using Model.Models;
using Repository;

namespace BusinessLogic
{
    public class DormBusinessLogic : IDormBusinessLogic
    {
        private readonly IDormRepository repository;
        private readonly IMapper mapper;

        public DormBusinessLogic(IDormRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public List<RoomDTO> GetRooms(DateTime? dateFrom, DateTime? dateTo)
        {
            DateTime from = dateFrom ?? DateTime.UtcNow.Date;
            DateTime to = dateTo ?? DateTime.UtcNow.Date;

            List<RoomEntity> entities = repository.GetAvailableRooms(from, to);

            return mapper.Map<List<RoomDTO>>(entities);
        }

        public void CreateBooking(CreateBookingModel model)
        {
            if (!repository.IsRoomAvailable(model.RoomId, model.DateFrom, model.DateTo))
            {
                throw new Exception("The Date Interval is already booked");
            }

            repository.CreateBooking(model.RoomId, model.DateFrom, model.DateTo);
        }
    }
}
