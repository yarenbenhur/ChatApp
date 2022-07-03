using ChatApp_Model;
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

       
    }

}

