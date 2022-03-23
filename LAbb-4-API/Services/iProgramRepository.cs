using LAbb_4_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAbb_4_API.Services
{
    public interface iProgramRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int Id);
        Task<T> Add(T newEntity);       
        Task<T> Delete(int Id);
        Task<T> Update(T Entity);
        Task<IEnumerable<T>> GetPeopleWInterests(int id);
        Task<IEnumerable<T>> GetWebbWithPerson(int id);



    }
}
