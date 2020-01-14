using EFProtocolDemo.Models.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EFProtocolDemo.Models.Repositories.Implementations
{
    public class CrudEFRepository<T> : CrudRepository<T> where T : class
    {
        protected EFProtocolDemoContext ctx;
        public CrudEFRepository(EFProtocolDemoContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var found = await ctx.Set<T>().FindAsync(id);
            if (found == null)
            {
                return false;

            }
            ctx.Set<T>().Remove(found);
            return true;
        }

        public IEnumerable<T> FindAll()
        {
            return ctx.Set<T>();
        }

        public async Task<T> FindByIdAsync(string id)
        {
           return await ctx.Set<T>().FindAsync(id);
        }

     
        public T Insert(T toInsert)
        {

            ctx.Set<T>().Add(toInsert);
            
            return toInsert;

        }

        public async Task<bool> UpdateAsync(string id, T toUpdate)
        {
            var found = await FindByIdAsync(id);
            if (found == null)
            {
                return false;
            }
            ctx.Set<T>().Update(toUpdate);
            return true;
        }



    }
}
