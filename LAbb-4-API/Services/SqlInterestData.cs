using LAbb_4_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAbb_4_API.Services
{
    public class SqlInterestData : iProgramRepository<Interests>
    {
        private ProgramDbContext _IntrestContext;

        public SqlInterestData(ProgramDbContext interestContext)
        {
            _IntrestContext = interestContext;
        }
        public async Task<Interests> Add(Interests newInterest)
        {

            var result = await _IntrestContext.Interests.AddAsync(newInterest);
            await _IntrestContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Interests> Delete(int Id)
        {
            var result = await _IntrestContext.Interests.FirstOrDefaultAsync(p => p.Id == Id);
            if (result != null)
            {
                _IntrestContext.Interests.Remove(result);
                await _IntrestContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        
        public async Task<IEnumerable<Interests>> GetAll()
        {
            return await _IntrestContext.Interests.ToListAsync();
        }

        public async Task<Interests> GetSingle(int Id)
        {
            return await _IntrestContext.Interests.
                FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Interests> Update(Interests interest)
        {
            var result = await _IntrestContext.Interests.FirstOrDefaultAsync(p => p.Id == interest.Id);
            if (result != null)
            {
                result.InterestName = interest.InterestName;
                result.InterestDescription = interest.InterestDescription;               

                await _IntrestContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Interests>> GetPeopleWInterests(int id)
        {
            var res = await _IntrestContext.Interests.Include(p => p.Person).Where(i => i.PersonId == id).ToListAsync();
            if (res != null)
            {
                return res;
            }
            return null;
        }

        Task<IEnumerable<Interests>> iProgramRepository<Interests>.GetWebbWithPerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}





