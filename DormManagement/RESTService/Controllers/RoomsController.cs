using BusinessLogic;
using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DormManagement.Controllers
{
    //TODO: DTOs should be mapp to a view model
    public class RoomsController : Controller
    {
        private readonly IRoomBusinessLogic businessLogic;

        public RoomsController(IRoomBusinessLogic businessLogic)
        {
            this.businessLogic = businessLogic;
        }

        [HttpGet]
        public List<RoomDTO> Get()
        {
            return businessLogic.GetRooms();
        }
    }
}
