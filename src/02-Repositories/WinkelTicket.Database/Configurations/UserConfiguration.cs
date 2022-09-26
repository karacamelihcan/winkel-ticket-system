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

            builder.HasMany(usr => usr.Tickets).WithMany(ticket => ticket.Assignees);

            builder.HasData(
                new User{
                    Id = "474de032-f1ed-4845-a6dc-15bf32c02e63",
                    Name = "Melihcan Kazım",
                    Surname = "Karaca",
                    UserName = "melihcan.karaca@winkel.com.tr",
                    NormalizedUserName = "MELIHCAN.KARACA@WINKEL.COM.TR",
                    Email = "melihcan.karaca@winkel.com.tr",
                    NormalizedEmail = "MELIHCAN.KARACA@WINKEL.COM.TR",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAELYQUIkW7lNhJdMbWZPYtgDmm2GxqBhN1ykOSm8Pw6IRqC13U1yw8ChYjLygSuoXRA==",
                    FullName = "Melihcan Kazım Karaca",
                    RoleId = "3a249142-9860-4781-b3f3-63b6e070cc45",
                    RoleName = "Admin"
                }
            );

        }
    }
}