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
    public class PlacesController : ControllerBase
    {
        private readonly IPlacesService _service;
        public PlacesController(IPlacesService service)
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
        [Route("AddPlace")]
        public async Task<IActionResult> Add(PlaceRequestModel model)
        {
            var cab = await _service.Add(model);
            return Ok(cab);
        }

        [HttpPut]
        [Route("UpdatePlace")]
        public async Task Update(PlaceRequestModel model)
        {
            await _service.Update(model);
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeletePlace")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
