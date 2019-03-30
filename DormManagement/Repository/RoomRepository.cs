using Model;
using Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    //This repository can inherit a generic repository in order to avoid 
    //too much work on crud operations -> LibraryRepository: GenericRepostory, ILibraryRepository...
    //Also, based on the complexity a generic repo per entity can be created -> BookingRepository: GenericRepostory<BookEntity>

    public class RoomRepository : IRoomRepository
    {
        private readonly DormManagementContext context;

        public RoomRepository(DormManagementContext context)
        {
            this.context = context;
        }

        public List<RoomEntity> GetRooms()
        {
            return context.Rooms.ToList();
        }
    }
}
