using EFProtocolDemo.Models.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;


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

            if (mail.ProtId != id)
            {
                return null;

            }
            return mail;
        }

        public Mail Insert(Mail mail)
        {
            Ctx.Mails.Add(mail);
            Ctx.SaveChanges();
            return mail;

            
        }

        public async Task<bool> UpdateAsync(string id, Mail toUpdate)
        {
            var found = Ctx.Mails.FindAsync(id);
            if (found == null)
            {
                return false;
            }
            Ctx.Set<Mail>().Update(toUpdate);
            await Ctx.SaveChangesAsync();
            return true;
        }

        public Task<Mail> FindLast()
        {
            
            var lastMail = Ctx.Mails.OrderByDescending(m => m.ProtId).FirstOrDefaultAsync();
            return lastMail;
        }

        //public Task<Mail> FindLast()
        //{
        //    var mail = new Mail();
        //    mail = "SELECT TOP(1) FROM Mails ORDER BY protId DESC";

        //}

        //public string FindLastId()
        //{
        //    //return Ctx.Mails.OrderByDescending(m => m.ProtId).Select(m => m.ProtId).Cast<Mail>();

        //    return  Ctx.Mails.OrderByDescending(m => m.ProtId).ToString();                      
        //}

    }
}
