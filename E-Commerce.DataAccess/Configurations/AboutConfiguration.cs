using E_Commerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.CompanyMail).IsRequired().HasMaxLength(80);
            builder.Property(x => x.CompanyAddress).IsRequired().HasMaxLength(250);
            builder.Property(x => x.CompanyPhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.ImagePath).IsRequired();
        }
    }
}
