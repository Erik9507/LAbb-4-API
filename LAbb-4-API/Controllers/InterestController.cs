using LAbb_4_API.Models;
using LAbb_4_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAbb_4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private iProgramRepository<Interests> _iProgram;
        public InterestController(iProgramRepository<Interests> iRepo)
        {
            this._iProgram = iRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
        {
            try
            {
                return Ok(await _iProgram.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Interests>> GetInterest(int id)
        {
            try
            {
                var result = await _iProgram.GetSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Interests>> CreateNewInterest(Interests newInterest)
        {
            try
            {
                var res = await _iProgram.Add(newInterest);
                if (res != null)
                {
                    return Created("", res);
                }
                return NotFound($"Error...");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error connecting to database");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Interests>> Delete(int id)
        {
            try
            {
                var interestToDelete = await _iProgram.GetSingle(id);
                if (interestToDelete == null)
                {
                    return NotFound($"Interest with id {id} not found");
                }
                return await _iProgram.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Interests>> UpdateInterest(int id, Interests inte)
        {
            try
            {
                if (id != inte.Id)
                {
                    return BadRequest("Interest id does not exist");
                }
                var interestToUpdate = await _iProgram.GetSingle(id);
                if (interestToUpdate == null)
                {
                    return NotFound($"Interest with id {id} not found");
                }
                return await _iProgram.Update(inte);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpGet("{getpersoninterest}")]
        public async Task<ActionResult<Interests>> GetPersonInterest(int id)
        {
            try
            {
                var res = await _iProgram.GetPeopleWInterests(id);
                if (res != null)
                {
                    
                    return Ok(res);
                }
                return NotFound("Error");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
           
        }
    }
}
