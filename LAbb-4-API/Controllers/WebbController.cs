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
    public class WebbController : ControllerBase
    {
        private iProgramRepository<WebbAdress> _iProgram;
        public WebbController(iProgramRepository<WebbAdress> wRepo)
        {
            this._iProgram = wRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWebb()
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
        public async Task<ActionResult<WebbAdress>> GetWebb(int id)
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
        public async Task<ActionResult<WebbAdress>> CreateNewWebb(WebbAdress newWebb)
        {
            try
            {
                if (newWebb == null)
                {
                    return BadRequest();
                }
                var createdWebb = await _iProgram.Add(newWebb);
                return CreatedAtAction(nameof(newWebb), new { id = createdWebb.Id }, createdWebb);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebbAdress>> Delete(int id)
        {
            try
            {
                var webbToDelete = await _iProgram.GetSingle(id);
                if (webbToDelete == null)
                {
                    return NotFound($"Webbadress with id {id} not found");
                }
                return await _iProgram.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebbAdress>> UpdateWebb(int id, WebbAdress webb)
        {
            try
            {
                if (id != webb.Id)
                {
                    return BadRequest("Webb id does not exist");
                }
                var interestToUpdate = await _iProgram.GetSingle(id);
                if (interestToUpdate == null)
                {
                    return NotFound($"Webb with id {id} not found");
                }
                return await _iProgram.Update(webb);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
    }
}
