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
        IMessageUserRepository MessageUserRepository { get; }
        IAnnouncementRepository AnnouncementRepository { get; }
        IAppUserRepository AppUserRepository { get; }
        IToDoListRepository ToDoListRepository { get; }
        IPortfolioRepository PortfolioRepository { get; }
        IMessageRepository MessageRepository { get; }
        IContactRepository ContactRepository { get; }
        IEducationRepository EducationRepository { get; }
        IFeatureRepository FeatureRepository { get; }
       ISettingRepository SettingRepository { get; }
        ISkillRepository SkillRepository { get; }
        Task<int> SaveChangesAsync();
        Task Commit();// => Başarılı bir işlemin sonucunda çalıştırılır. İşlemin başalamasından itibaren tüm değişikliklerin veri tabanına uyhulanmasını temin eder.

    

    }
}
