using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sharedProject.IDAO;
using sharedProject.model;

namespace WebAPI_Parking.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    public class ParkingController : ControllerBase
    {
        IDAOParking DAOParking;
        public ParkingController(IDAOParking p )
        {
            DAOParking = p;
        }

        [HttpGet("allParkings")]
        public async Task<ActionResult<List<Parking>>> getparking()
        {
            return DAOParking.findAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Parking>>> getParking(int id)
        {
            return Ok(DAOParking.GetById(id));
        }

        [HttpDelete("deleteParking")]
        public IActionResult deleteParking(Parking p)
        {
            return Ok(DAOParking.Delete(p));
        }

        [HttpPost("addParking")]
        public async Task<ActionResult<List<Parking>>> addParking(Parking p)
        {
            return Ok(DAOParking.Add(p));
        }

        [HttpPut("updateParking/{id}")]
        public async Task<ActionResult<List<Parking>>> updateParking(int id, Parking p)
        {
            return Ok(DAOParking.Update(id, p));
        }
    }
}
