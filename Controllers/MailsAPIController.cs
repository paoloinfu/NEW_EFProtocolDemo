using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFProtocolDemo;

namespace EFProtocolDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsAPIController : ControllerBase
    {
        private readonly EFProtocolDemoContext _context;

        public MailsAPIController(EFProtocolDemoContext context)
        {
            _context = context;
        }

        // GET: api/MailsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mail>>> GetMails()
        {
            return await _context.Mails.ToListAsync();
        }

        // GET: api/MailsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mail>> GetMail(string id)
        {
            var mail = await _context.Mails.FindAsync(id);

            if (mail == null)
            {
                return NotFound();
            }

            return mail;
        }

        // PUT: api/MailsAPI/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMail(string id, Mail mail)
        {
            if (id != mail.ProtId)
            {
                return BadRequest();
            }

            _context.Entry(mail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MailsAPI
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Mail>> PostMail(Mail mail)
        {
            _context.Mails.Add(mail);
            try
            {
                await _context.SaveChangesAsync();
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

        // DELETE: api/MailsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mail>> DeleteMail(string id)
        {
            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }

            _context.Mails.Remove(mail);
            await _context.SaveChangesAsync();

            return mail;
        }

        private bool MailExists(string id)
        {
            return _context.Mails.Any(e => e.ProtId == id);
        }

    }
}
