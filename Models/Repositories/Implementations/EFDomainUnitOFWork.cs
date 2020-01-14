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
        public MailRepository MailRepository { get ; set; }

        public EFDomainUnitOFWork(MailRepository mailRepository)
        {
            MailRepository = mailRepository;
        }
            

        public Task<Mail> FindByIdAsync(string id)
        {
            return MailRepository.FindByIdAsync(id);
        }

        public Task<bool> DeleteAsync(string id)
        {
            return MailRepository.DeleteAsync(id);
        }

        public async Mail Insert(Mail toInsert)
        {
           var lastMail = await MailRepository.FindLast();
            if (lastMail == null) 
            {
                toInsert.GenerateId(0);
            }
            else
            {
                var stringLastId = lastMail.ProtId.Substring(0, lastMail.ProtId.IndexOf("_"));
                var lastId = Int32.Parse(stringLastId);
                toInsert.GenerateId(lastId + 1);
                
            }
           return  MailRepository.Insert(toInsert);
        }

        public Task<bool> UpdateAsync(string id, Mail toUpdate)
        {
            return MailRepository.UpdateAsync(id, toUpdate);
        }

        public Task<IEnumerable<Mail>> FindAll()
        {
            return MailRepository.FindAll();
        }
    }
}
