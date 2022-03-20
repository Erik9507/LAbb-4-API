using LAbb_4_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAbb_4_API.Services
{
    public class SqlWebbAdressData : iProgramRepository<WebbAdress>
    {
        private ProgramDbContext _webbContext;

        public SqlWebbAdressData(ProgramDbContext webbContext)
        {
            _webbContext = webbContext;
        }
        public async Task<WebbAdress> Add(WebbAdress newWebb)
        {
            var result = await _webbContext.WebbAdresses.AddAsync(newWebb);
            await _webbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<WebbAdress> Delete(int Id)
        {
            var result = await _webbContext.WebbAdresses.FirstOrDefaultAsync(p => p.Id == Id);
            if (result != null)
            {
                _webbContext.WebbAdresses.Remove(result);
                await _webbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<WebbAdress>> GetAll()
        {
            return await _webbContext.WebbAdresses.ToListAsync();
        }

        public async Task<WebbAdress> GetSingle(int Id)
        {
            return await _webbContext.WebbAdresses.
                FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<WebbAdress> Update(WebbAdress webb)
        {
            var result = await _webbContext.WebbAdresses.FirstOrDefaultAsync(p => p.Id == webb.Id);
            if (result != null)
            {
                result.WebbSiteName = webb.WebbSiteName;
                result.Webbadress = webb.Webbadress;

                await _webbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
