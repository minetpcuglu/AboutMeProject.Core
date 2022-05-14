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
   public class MessageUserMap : BaseMap<MessageUser>
    {
        public override void Configure(EntityTypeBuilder<MessageUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MessageContent).HasMaxLength(1000).IsRequired(true);
            builder.Property(x => x.SenderMail).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.ReceiverMail).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Subject).HasMaxLength(150).IsRequired(true);


            base.Configure(builder);
        }

    }
}
