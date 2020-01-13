using EFProtocolDemo.Models.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
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

        public EFDomainUnitOFWork(EFProtocolDemoContext ctx, MailRepository mailRepository)
        {
            this.ctx = ctx;
            this.MailRepository = mailRepository;
        }
        public async Task<IEnumerable<Mail>> FindAllMailAsync()
        {
            return await MailRepository.FindAll().AsQueryable().ToListAsync();
        }
    }
}
