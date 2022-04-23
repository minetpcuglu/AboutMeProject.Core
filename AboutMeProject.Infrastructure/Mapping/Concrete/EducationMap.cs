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
   public class EducationMap : BaseMap<Education>
    {
        public override void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SchollName).HasMaxLength(70).IsRequired(true);
            builder.Property(x => x.Date).IsRequired(true);
            builder.Property(x => x.Section).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.NoteAvarage).HasMaxLength(5).IsRequired(true);


            base.Configure(builder);

        }
    }
}
