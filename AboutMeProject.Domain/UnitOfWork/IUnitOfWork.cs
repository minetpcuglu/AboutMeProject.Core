﻿using AboutMeProject.Domain.Repository.EntityTypeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Domain.UnitOfWork
{
   public interface IUnitOfWork : IAsyncDisposable
    {
        IAboutRepository AboutRepository { get; }
        
        Task Commit();// => Başarılı bir işlemin sonucunda çalıştırılır. İşlemin başalamasından itibaren tüm değişikliklerin veri tabanına uyhulanmasını temin eder.

    

    }
}
