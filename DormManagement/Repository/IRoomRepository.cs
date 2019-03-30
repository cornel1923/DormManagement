using Model.Models;
using System.Collections.Generic;

namespace Repository
{
    public interface IRoomRepository
    {
        List<RoomEntity> GetRooms();
    }
}
