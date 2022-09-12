using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinkelTicket.Core.Models;

namespace WinkelTicket.Database.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(ticket => ticket.Id);
            builder.Property(ticket => ticket.Description).IsRequired();
            builder.Property(ticket => ticket.Title).IsRequired();

            builder.HasOne(ticket => ticket.Creator).WithMany();
            builder.HasMany(ticket => ticket.Comments).WithOne();
            builder.HasMany(ticket => ticket.Assignees).WithMany(user => user.Tickets);
        }
    }
}