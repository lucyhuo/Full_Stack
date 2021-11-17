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
    public class CabTypesController : ControllerBase
    {
        private readonly ICabTypesService _cabTypesService;
        public CabTypesController(ICabTypesService cabTypesService)
        {
            _cabTypesService = cabTypesService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCabTypes([FromQuery] int pageSize = 30, [FromQuery] int pageIndex = 1)
        {
            var dbCabs = await _cabTypesService.GetCabTypesAsync();
            return Ok(dbCabs);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBookingDetailsForCabType(int id)
        {
            var dbCabs = await _cabTypesService.GetBookingsForCabType(id);
            return Ok(dbCabs);
        }

        [HttpPost]
        [Route("AddCabType")]
        public async Task<IActionResult> AddCabType(CabTypeRequestModel model)
        {
            var cab = await _cabTypesService.AddCabType(model);
            return Ok(cab);
        }

        [HttpPut]
        [Route("UpdateCabType")]
        public async Task UpdateCabType(CabTypeRequestModel model)
        {
            await _cabTypesService.UpdateCabType(model);
        }

        [HttpDelete]
        [Route("{id:int}", Name = "DeleteCabType")]
        public async Task DeleteCabType(int id)
        {
             await _cabTypesService.DeleteCabType(id);
        }

    }
}
