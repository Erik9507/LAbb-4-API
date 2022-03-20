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
    public class PersonController : ControllerBase
    {
        private iProgramRepository<Person> _iProgram;
        public PersonController(iProgramRepository<Person> pRepo)
        {
            this._iProgram = pRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
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
        public async Task<ActionResult<Person>> GetPerson(int id)
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
        public async Task<ActionResult<Person>> CreateNewPerson(Person newPerson)
        {
            try
            {
                if (newPerson == null)
                {
                    return BadRequest();
                }
                var createdPerson = await _iProgram.Add(newPerson);
                return CreatedAtAction(nameof(GetPerson), new { id = createdPerson.Id }, createdPerson);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> Delete(int id)
        {
            try
            {
                var personToDelete = await _iProgram.GetSingle(id);
                if (personToDelete == null)
                {
                    return NotFound($"Person with id {id} not found");
                }
                return await _iProgram.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> UpdatePerson(int id, Person per)
        {
            try
            {
                if (id != per.Id)
                {
                    return BadRequest("Person id does not exist");
                }
                var personToUpdate = await _iProgram.GetSingle(id);
                if (personToUpdate == null)
                {
                    return NotFound($"Person with id {id} not found");
                }
                return await _iProgram.Update(per);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpGet("{Id}")] 
        public async Task<ActionResult<Person>> GetpeopleWithInterest(int id)
        {
            try
            {
                var result = await _iProgram.GetPeopleWInterests(id);
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

    }
}
