using AboutMeProject.Domain.Repository.EntityTypeRepository;
using AboutMeProject.Domain.UnitOfWork;
using AboutMeProject.Infrastructure.Context;
using AboutMeProject.Infrastructure.Repository.EntityTypeRepo;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork // => IUnitOfWork'den implement yolu ile gövdelendireceğim methodlarımı aldım.
    {
        private readonly ApplicationDbContext _db;
        private IDbContextTransaction _transation;
        public UnitOfWork(ApplicationDbContext db)
        {
            this._db = db ?? throw new ArgumentNullException("Database Can Not To Be Null..!");
        }
        //=> ??= Karar mekanizmasını başlattık. Bu karar mekanizması ya bize db bağlantısını verecek ya da ArgumentNullException ile hata mesajımı gönderecektir.

        private IAboutRepository aboutRepository;
        public IAboutRepository AboutRepository
        {
            get
            {
                if (aboutRepository == null) aboutRepository = new AboutRepository(_db); //=> _appRepository boş gelirse database bağlantısını üret.
                return aboutRepository; //=> eğer dolu gelirse bağlı olan _appRepository yu bana geri ver
            }
        }

        public async Task Commit() => await _db.SaveChangesAsync();

        public async Task<int> SaveChangesAsync()
        {
            var transaction = _transation ?? _db.Database.BeginTransaction();
            var count = 0;

            using (transaction)
            {
                try
                {
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }

            return count;
        }

        private bool isDisposing = false;
        public async ValueTask DisposeAsync()
        {
            if (!isDisposing)
            {
                isDisposing = true;
                await DisposeAsync(true);
                GC.SuppressFinalize(this);// Nesnemizi tamamıyla temizlenmesini sağlayack.
            }
        }
        private async Task DisposeAsync(bool disposing)
        {
            if (disposing) await _db.DisposeAsync(); // => Üretilen db nesnemizi dispose ettik.
        }
    }
}

