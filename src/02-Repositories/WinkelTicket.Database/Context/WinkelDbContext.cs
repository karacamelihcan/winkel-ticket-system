using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WinkelTicket.Core.Models;

namespace WinkelTicket.Database.Context
{
    public class WinkelDbContext : IdentityDbContext<User,UserRoles,string>
    {
        public WinkelDbContext(DbContextOptions<WinkelDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}