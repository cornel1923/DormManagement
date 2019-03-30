using System.Collections.Generic;
using AutoMapper;
using BusinessLogic.DTOs;
using Model.Models;
using Repository;

namespace BusinessLogic
{
    public class RoomBusinessLogic : IRoomBusinessLogic
    {
        private readonly IRoomRepository repository;
        private readonly IMapper mapper;

        public RoomBusinessLogic(IRoomRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public List<RoomDTO> GetRooms()
        {
            List<RoomEntity> entities = repository.GetRooms();

            return mapper.Map<List<RoomDTO>>(entities);
        }
    }
}
