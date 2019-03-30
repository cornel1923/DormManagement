using BusinessLogic.DTOs;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IRoomBusinessLogic
    {
        List<RoomDTO> GetRooms();
    }
}
