using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFProtocolDemo.Models.Repositories.Abstractions
{
    public interface CrudRepository<T> 
    {
        Task<T> FindByIdAsync(string id);
        Task<bool> DeleteAsync(string id);
        T Insert(T toInsert);
        Task<bool> UpdateAsync(string id, T toUpdate);
        IEnumerable<T> FindAll();

    }
}


