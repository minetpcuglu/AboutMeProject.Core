﻿using AboutMeProject.Domain.Repository.EntityTypeRepository;
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
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}