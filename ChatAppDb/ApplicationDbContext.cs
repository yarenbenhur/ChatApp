using ChatApp_Model;
using ChatApp_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChatApp_DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        //public DbSet<Friendship> Friendship { get; set; }

       
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Friendship>().HasKey(b => new { b.UserId, b.FriendUserId });
        //    modelBuilder.Entity<Friendship>().HasOne(b => b.User).WithMany(b => b.Friendship);
        //}

    }

}

