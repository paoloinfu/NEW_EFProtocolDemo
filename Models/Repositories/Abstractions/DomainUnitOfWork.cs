﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFProtocolDemo.Models.Repositories.Abstractions
{
    public interface DomainUnitOfWork
    {
        MailRepository MailRepository { get; set; }
        Task<Mail> FindByIdAsync(string id);
        Task<bool> DeleteAsync(string id);
        Task<Mail> Insert(Mail toInsert);
        Task<bool> UpdateAsync(string id, Mail toUpdate);
        Task<IEnumerable<Mail>> FindAllAsync();
    }
}
