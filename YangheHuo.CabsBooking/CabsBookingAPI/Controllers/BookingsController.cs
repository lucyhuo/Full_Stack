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
    public class BookingsController : ControllerBase
    {
        private readonly IBookingsService _service;
        public BookingsController(IBookingsService service)
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
        [Route("AddBooking")]
        public async Task<IActionResult> Add(BookingsRequestModel model)
        {
            var cab = await _service.Add(model);
            return Ok(cab);
        }

        [HttpPut]
        [Route("UpdateBooking")]
        public async Task Update(BookingsRequestModel model)
        {
            await _service.Update(model);
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteBooking")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }

    }
}
