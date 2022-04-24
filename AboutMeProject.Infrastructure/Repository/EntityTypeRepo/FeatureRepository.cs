using AboutMeProject.Domain.Entities.Concrete;
using AboutMeProject.Domain.Repository.EntityTypeRepository;
using AboutMeProject.Infrastructure.Context;
using AboutMeProject.Infrastructure.Repository.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Infrastructure.Repository.EntityTypeRepo
{
   public class FeatureRepository : BaseRepository<Feature>, IFeatureRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public FeatureRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

    }
}
