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
    public class SocialMediaMap : BaseMap<SocialMedia>
    {
        public override void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(400).IsRequired(true);
            base.Configure(builder);

        }
    }
}
