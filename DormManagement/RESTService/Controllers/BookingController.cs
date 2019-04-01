using AutoMapper;
using BusinessLogic;
using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using RESTService.ViewModels;
using System.Collections.Generic;

namespace DormManagement.Controllers
{
    public class BookingController : Controller
    {
        private readonly IDormBusinessLogic businessLogic;
        private readonly IMapper mapper;

        public BookingController(IDormBusinessLogic businessLogic, IMapper mapper)
        {
            this.businessLogic = businessLogic;
            this.mapper = mapper;
        }

        [HttpPost]
        public void Create([FromBody]CreateBookingViewModel viewModel)
        {
            CreateBookingModel model = mapper.Map<CreateBookingModel>(viewModel);

            businessLogic.CreateBooking(model);
        }
    }
}
