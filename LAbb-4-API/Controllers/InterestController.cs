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
        [HttpGet("{Id}")]
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
                if (newInterest == null)
                {
                    return BadRequest();
                }
                var createdInterest = await _iProgram.Add(newInterest);
                return CreatedAtAction(nameof(newInterest), new { id = createdInterest.Id }, createdInterest);
            }
            catch (Exception)
            {
                throw;
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
    }
}
