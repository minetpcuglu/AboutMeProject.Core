using AboutMeProject.Domain.Repository.EntityTypeRepository;
using AboutMeProject.Domain.UnitOfWork;
using AboutMeProject.Infrastructure.Repository.EntityTypeRepo;
using AboutMeProject.Infrastructure.UnitOfWork;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Application.Utilities.IoC
{
   public class RepositoryModule: Module //UnitOfWork için bagımlılıklardan kurtulmak amacıyla IoC Containerlardan yardım almak 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutRepository>().As<IAboutRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MessageUserRepository>().As<IMessageUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AnnouncementRepository>().As<IAnnouncementRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ToDoListRepository>().As<IToDoListRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ContactRepository>().As<IContactRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MessageRepository>().As<IMessageRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserMessageRepository>().As<IUserMessageRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EducationRepository>().As<IEducationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PortfolioRepository>().As<IPortfolioRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SkillRepository>().As<ISkillRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SettingRepository>().As<ISettingRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FeatureRepository>().As<IFeatureRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
