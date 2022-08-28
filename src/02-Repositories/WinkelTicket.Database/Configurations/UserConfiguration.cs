using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinkelTicket.Core.Models;

namespace WinkelTicket.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(usr => usr.Name).IsRequired();
            builder.Property(usr => usr.Surname).IsRequired();
        }
    }
}