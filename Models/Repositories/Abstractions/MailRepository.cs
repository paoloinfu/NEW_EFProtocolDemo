using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFProtocolDemo.Models.Repositories.Abstractions
{
    public interface MailRepository
    {
        public EFProtocolDemoContext Ctx{ get; set; }

        Task<Mail> FindByIdAsync(string id);
        Task<bool> DeleteAsync(string id);
        Mail Insert(Mail toInsert);
        Task<bool> UpdateAsync(string id, Mail toUpdate);
        Task<IEnumerable<Mail>> FindAllAsync();

        public Task<Mail> FindLast();
 
    }
}
