using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFProtocolDemo.Models.Repositories.Abstractions
{
    interface DomainUnitOfWork
    {
        MailRepository MailRepository { get; set; }
        public Task<IEnumerable<Mail>> FindAllMailAsync();
    }
}
