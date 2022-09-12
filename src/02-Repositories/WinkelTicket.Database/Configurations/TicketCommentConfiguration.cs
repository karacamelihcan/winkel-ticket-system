using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinkelTicket.Core.Models;

namespace WinkelTicket.Database.Configurations
{
    public class TicketCommentConfiguration : IEntityTypeConfiguration<TicketComment>
    {
        public void Configure(EntityTypeBuilder<TicketComment> builder)
        {
            builder.HasKey(comm => comm.Id);
            builder.Property(comm => comm.Message).IsRequired();
            builder.HasMany(comm => comm.Files).WithOne();
            builder.HasOne(comm => comm.Sender).WithMany();
        }
    }
}