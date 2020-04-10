using DataDB.Data;
using DataDB.Models;
using DataDB.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Repository
{
    public class FeedRepository : IFeedRepository
    {

        #region Constructor
        public FeedRepository()
        {

        }
        #endregion

        #region Public Methods

        public async Task<List<Feed>> GetFeeds()
        {
            using (var context = new DataContext())
            {
                return await context.Feeds.ToListAsync();
            }
        }

        public async Task<List<FeedItem>> GetFeedItems(int feedId)
        {
            using (var context = new DataContext())
            {
                Feed feed = await context.Feeds.FirstOrDefaultAsync(_feed=> _feed.Id == feedId);

                if (feed == null)
                {
                    return null;
                }
                List<FeedItem> list = await context.FeedItems.Where(item => item.Feed.Id == feed.Id)
                    .ToListAsync();

                return list;
            }
        }

        public async Task<List<Feed>> GetFeedItems(string email)
        {
            using (var context = new DataContext())
            {
                context.Configuration.LazyLoadingEnabled = false;

                User currentUser =  await context.Users.FirstOrDefaultAsync(user => user.Email == email);

                var aa = context.Users.ToList();
                var aba = context.Feeds.ToList();
                var aaa = context.FeedItems.ToList();
                var aaca = context.UserFeeds.ToList();

                if (currentUser != null)
                {
                    return await context.UserFeeds
                        .Where(userFeed => userFeed.UserId == currentUser.Id)
                        .Select(a => a.Feed)
                        .ToListAsync();
                       
                }

                return null;
            }
        }

        public async Task<UserFeed> SuscribeToFeed(int feedId, string email)
        {
            using (var context = new DataContext())
            {
                Feed feed = await context.Feeds.FirstOrDefaultAsync(_feed => _feed.Id == feedId);
                User currentUser = await context.Users.FirstOrDefaultAsync(user => user.Email == email);

                if (currentUser == null || feed == null)
                {
                    return null;
                }
                UserFeed userFeed = new UserFeed() { FeedId = feed.Id, UserId = currentUser.Id };
                context.UserFeeds.Add(userFeed); 
                context.SaveChanges();
                return userFeed;

            }
        }

       
        #endregion


    }
}
