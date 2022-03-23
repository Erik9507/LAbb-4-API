using LAbb_4_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAbb_4_API.Services
{
    public class SqlPersonData : iProgramRepository<Person>
    {
        private ProgramDbContext _personContext;

        public SqlPersonData(ProgramDbContext personContext)
        {
            _personContext = personContext;
        }

        public async Task<Person> Add(Person newPerson)
        {
            var result = await _personContext.People.AddAsync(newPerson);
            await _personContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Person> Delete(int Id)
        {
            var result = await _personContext.People.FirstOrDefaultAsync(p => p.Id == Id);
            if (result != null)
            {
                _personContext.People.Remove(result);
                await _personContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _personContext.People.ToListAsync();
        }

        public async Task<Person> GetSingle(int Id)
        {
            return await _personContext.People.
                FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Person> Update(Person person)
        {
            var result = await _personContext.People.FirstOrDefaultAsync(p => p.Id == person.Id);
            if (result != null)
            {
                result.Name = person.Name;
                result.PhoneNumber = person.PhoneNumber;

                await _personContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        Task<IEnumerable<Person>> iProgramRepository<Person>.GetPeopleWInterests(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Person>> iProgramRepository<Person>.GetWebbWithPerson(int id)
        {
            throw new NotImplementedException();
        }
    }    
}
