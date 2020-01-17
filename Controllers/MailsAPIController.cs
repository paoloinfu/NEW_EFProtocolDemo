using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFProtocolDemo;
using EFProtocolDemo.Models.Repositories.Implementations;

namespace EFProtocolDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsAPIController : ControllerBase
    {
        public EFDomainUnitOFWork _context;

        public MailsAPIController(EFDomainUnitOFWork context)
        {
            _context = context;
        }

        // GET: api/MailsAPI
        [HttpGet]
        public async Task<IEnumerable<Mail>> GetMails()
        {
            return await _context.FindAllAsync();
        }

        // GET: api/MailsAPI/5
        [HttpGet("{id}")]
        public async Task<Mail> GetMail(string id)
        {
            var mail = await _context.FindByIdAsync(id);

            if (mail == null)
            {
                return null;
            }

            return mail;
        }

        // PUT: api/MailsAPI/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<Mail> PutMail(string id, Mail mail)
        {
            if (id != mail.ProtId)
            {
                return null;
            }

            await _context.UpdateAsync(id, mail);
            return mail;
        }

        // POST: api/MailsAPI
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<Mail> PostMail(Mail mail)
        {
            await _context.Insert(mail);
            return mail;
        }

        // DELETE: api/MailsAPI/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteMail(string id)
        {
            var mail = await _context.FindByIdAsync(id);
            if (mail == null)
            {
                return false;
            }

            await _context.DeleteAsync(id);
            return true;
        }

    }
}
