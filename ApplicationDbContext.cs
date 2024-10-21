using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpt_integration.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace gpt_integration;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Chat> Chats { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().HasMany(p => p.Chats).WithOne(p => p.User);
        builder.Entity<Chat>().HasMany(p => p.ChatMessages).WithOne(p => p.Chat);

        builder.HasDefaultSchema("gptintegration");
    }
}
