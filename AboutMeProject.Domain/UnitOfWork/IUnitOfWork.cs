using AboutMeProject.Domain.Repository.EntityTypeRepository;
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
        IAppUserRepository AppUserRepository { get; }
        IToDoListRepository ToDoListRepository { get; }
        IUserRepository UserRepository { get; }
        IPortfolioRepository PortfolioRepository { get; }
        IMessageRepository MessageRepository { get; }
        IUserMessageRepository UserMessageRepository { get; }
        IContactRepository ContactRepository { get; }
        IEducationRepository EducationRepository { get; }
        IFeatureRepository FeatureRepository { get; }
       ISettingRepository SettingRepository { get; }
        ISkillRepository SkillRepository { get; }
        Task<int> SaveChangesAsync();
        Task Commit();// => Başarılı bir işlemin sonucunda çalıştırılır. İşlemin başalamasından itibaren tüm değişikliklerin veri tabanına uyhulanmasını temin eder.

    

    }
}
