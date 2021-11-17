using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabsBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsHistoriesController : ControllerBase
    {
        private readonly IBookingsHistoriesService _service;
        public BookingsHistoriesController(IBookingsHistoriesService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAll();
            return Ok(data);
        }

        [HttpPost]
        [Route("AddBookingHistory")]
        public async Task<IActionResult> Add(BookingHistoriesRequestModel model)
        {
            var cab = await _service.Add(model);
            return Ok(cab);
        }

        [HttpPut]
        [Route("UpdateBookingHistory")]
        public async Task Update(BookingHistoriesRequestModel model)
        {
            await _service.Update(model);
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteBookingHistory")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }

    }
}
