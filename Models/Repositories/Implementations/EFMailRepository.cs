using EFProtocolDemo.Models.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFProtocolDemo.Models.Repositories.Implementations
{
    public class EFMailRepository :  MailRepository
    {

        public EFProtocolDemoContext Ctx { get; set; }
        public EFMailRepository(EFProtocolDemoContext ctx)
        {
            Ctx = ctx;
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Mail>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Mail> FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Mail Insert(Mail toInsert)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(string id, Mail toUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<Mail> FindLast() {
            return null;
        }
    }
}
