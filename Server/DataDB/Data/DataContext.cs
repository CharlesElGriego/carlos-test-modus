using DataDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Data
{
    public class DataContext : DbContext
    {
        public DataContext(): base("DataContext")
        {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feed>()
                .ToTable("Feed");

            modelBuilder.Entity<User>()
                 .ToTable("User");
           
        }

        public DbSet<Feed> Feeds { get; set; }
        public DbSet<FeedItem> FeedItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFeed> UserFeeds { get; set; }
    }
}
