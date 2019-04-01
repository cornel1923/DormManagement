using AutoMapper;
using BusinessLogic.DTOs;
using Model.Models;

namespace BusinessLogic
{
    public class DTOEntityMappingProfile : Profile
    {
        public DTOEntityMappingProfile()
        {
            CreateMap<RoomEntity, RoomDTO>().ReverseMap();
            CreateMap<BookingEntity, BookingDTO>();
        }
    }
}
