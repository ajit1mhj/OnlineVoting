using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineVoting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Infrastructure.Data
{
    public class VotingContext : IdentityDbContext<ApplicationUser>
    {
        public VotingContext(DbContextOptions<VotingContext> options) : base(options)
        {
        }
        public DbSet<VoteGroup> VoteGroups { get; set; }
        public DbSet<Vote> Votes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Vote>()
                .HasOne(v => v.VoteGroup)
                .WithMany(g => g.Votes)
                .HasForeignKey(v => v.UserId);
            builder.Entity<Vote>()
             .HasOne(v => v.VoteGroup)
             .WithMany(g => g.Votes)
             .HasForeignKey(v => v.GroupId);
        }
            
    }
}
