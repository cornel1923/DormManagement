using BusinessLogic;
using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using RESTService.ViewModels;
using System.Collections.Generic;

namespace DormManagement.Controllers
{
    //TODO: DTOs should be mapp to a view model

    public class RoomController : Controller
    {
        private readonly IDormBusinessLogic businessLogic;

        public RoomController(IDormBusinessLogic businessLogic)
        {
            this.businessLogic = businessLogic;
        }

        [HttpGet]
        public List<RoomDTO> Get([FromQuery]RoomDateFilterViewModel viewModel)
        {
            return businessLogic.GetRooms(viewModel.DateFrom, viewModel.DateTo);
        }
    }
}
