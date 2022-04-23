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
   public class AboutMap : BaseMap<About>
    {
        public override void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired(true);
            builder.Property(x => x.Adress).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Age).HasMaxLength(4).IsRequired(true);
            builder.Property(x => x.Mail).HasMaxLength(40).IsRequired(true);
            builder.Property(x => x.Phone).HasMaxLength(11).IsRequired(true);
            builder.Property(x => x.Title).HasMaxLength(250).IsRequired(true);
            builder.Property(x => x.ImageUrl).HasMaxLength(500).IsRequired(true);
  

            base.Configure(builder);
        }

    }
}
