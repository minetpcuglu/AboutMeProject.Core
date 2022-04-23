
using AboutMeProject.Domain.Entities.Concrete;
using AboutMeProject.Infrastructure.Mapping.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutMeProject.Infrastructure.Context
{
   public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } // =>  "DB bağlantısını concructor method ile oluşturuldu."

        public DbSet<SocialMedia> SocialMedias{ get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }


        // Şimdi yaptığımız Map'leme işlemini override edeceğiz.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AboutMap());
            builder.ApplyConfiguration(new EducationMap());
            builder.ApplyConfiguration(new TestimonialMap());
            builder.ApplyConfiguration(new FeatureMap());
            builder.ApplyConfiguration(new SkillMap());
            builder.ApplyConfiguration(new MessageMap());
            builder.ApplyConfiguration(new PortfolioMap());
            builder.ApplyConfiguration(new ServiceMap());
            builder.ApplyConfiguration(new SocialMediaMap());
            builder.ApplyConfiguration(new ContactMap());

            base.OnModelCreating(builder);
        }

    }
}
