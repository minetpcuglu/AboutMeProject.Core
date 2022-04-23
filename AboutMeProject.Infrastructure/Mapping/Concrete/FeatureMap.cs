using AboutMeProject.Domain.Entities.Concrete;
using AboutMeProject.Infrastructure.Mapping.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Infrastructure.Mapping.Concrete
{
   public class FeatureMap : BaseMap<Feature>
    {
        public override void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(70).IsRequired(true);
            builder.Property(x => x.Haeder).IsRequired(true);
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired(true);

            base.Configure(builder);

        }
    }
}
