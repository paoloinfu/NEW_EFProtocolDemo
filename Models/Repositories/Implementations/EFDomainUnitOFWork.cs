using EFProtocolDemo.Models.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFProtocolDemo.Models.Repositories.Implementations
{
    public class EFDomainUnitOFWork : DomainUnitOfWork
    {
        private EFProtocolDemoContext ctx;
        public MailRepository MailRepository { get ; set; }

        public Task<IEnumerable<Mail>> FindAllMailAsync()
        {
            throw new NotImplementedException();
        }
    }
}
