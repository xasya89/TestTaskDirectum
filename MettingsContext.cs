using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDirectum.DAO;
using TestTaskDirectum.Entities;

namespace TestTaskDirectum
{
    public class MettingsContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingUser> MeetingsUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "MettingsDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MeetingUser>()
                .HasOne(x => x.Meeting)
                .WithMany(x => x.MeetingUsers)
                .HasForeignKey(x => x.MeetingId);
        }
    }
}
