using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinkelTicket.Core.Models;

namespace WinkelTicket.Database.Configurations
{
    public class TicketFileConfiguration : IEntityTypeConfiguration<TicketFile>
    {
        public void Configure(EntityTypeBuilder<TicketFile> builder)
        {
            builder.HasKey(file => file.Id);
            builder.Property(file => file.Description).IsRequired();
            builder.Property(file => file.Path).IsRequired();
        }
    }
}