using EFProtocolDemo.Models.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> DeleteAsync(string id)
        {
            var mail = await Ctx.Mails.FindAsync(id);
            if (mail == null)
            {
                return false; 
            }
            Ctx.Mails.Remove(mail);
            await Ctx.SaveChangesAsync();
            return true;   
        }

        public async Task<IEnumerable<Mail>> FindAllAsync()
        {
            return await Ctx.Mails.ToListAsync();
        }

        public async Task<Mail> FindByIdAsync(string id)
        {
            var mail = await Ctx.Mails.FindAsync(id);

            if (mail == null)
            {
                return mail;

            }
            return mail;
        }

        public async Mail Insert(Mail mail)
        {
            Ctx.Mails.Add(mail);
            try
            {
                await Ctx.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MailExists(mail.ProtId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMail", new { id = mail.ProtId }, mail);
        }

        public Task<bool> UpdateAsync(string id, Mail toUpdate)
        {
           
        }

        public Task<Mail> FindLast() {
            return null;
        }
    }
}
