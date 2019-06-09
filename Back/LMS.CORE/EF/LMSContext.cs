using LMS.DATA.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.CORE.EF
{
    public class LMSContext: IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public LMSContext(DbContextOptions<LMSContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Participant>()
                .HasKey(p => new { p.GroupId, p.UserId });

            modelBuilder.Entity<Administration>()
                .HasKey(a => new { a.DirectionId, a.UserId });
        }

        public DbSet<Direction> Directions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Administration> Administration { get; set; }
        public DbSet<AdministrationRole> AdministrationRoles { get; set; }
        public DbSet<BlockType> BlockTypes { get; set; }
        public DbSet<ParticipantRole> ParticipantRoles { get; set; }
    }
}
