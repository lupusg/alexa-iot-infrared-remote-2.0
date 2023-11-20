﻿using AlexaIOTInfraredRemoteAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Database
{
    public class AiirContext : DbContext
    {
        public AiirContext(DbContextOptions<AiirContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<InfraredSignal> InfraredSignals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.InfraredSignals)
                .WithOne()
                .HasForeignKey(signal => signal.UserId);
        }
    }
}
