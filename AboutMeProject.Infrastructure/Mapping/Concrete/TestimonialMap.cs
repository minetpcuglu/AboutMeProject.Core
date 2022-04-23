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
   public class TestimonialMap : BaseMap<Testimonial>
    {
        public override void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClientName).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Comment).IsRequired(true);
            builder.Property(x => x.Company).IsRequired(true);

            base.Configure(builder);

        }
    }
}
