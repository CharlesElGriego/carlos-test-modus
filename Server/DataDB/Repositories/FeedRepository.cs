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

        #region Public Methods

        public async Task<List<Feed>> GetFeeds(string email)
        {
            using (var context = new DataContext())
            {
                User currentUser = await context.Users.FirstOrDefaultAsync(user => user.Email == email);

                if (currentUser != null)
                {
                    List<Feed> feeds = await context.Feeds.Include(f => f.UserFeeds).ToListAsync();

                    return feeds.Select(f => 
                        new Feed{
                           Id = f.Id, 
                           FeedName = f.FeedName,
                           Image = f.Image,
                           IsSubscribed = f.UserFeeds.Any( uf => uf.UserId == currentUser.Id && uf.FeedId == f.Id)
                        }).ToList();
                }

                return null;
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

        public async Task<List<Feed>> GetFeedItems(string email, bool withItems)
        {
            using (var context = new DataContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                User currentUser =  await context.Users.FirstOrDefaultAsync(user => user.Email == email);

                if (currentUser != null)
                {
                    List<UserFeed> userFeeds = new List<UserFeed>();
                    if (withItems)
                    {
                       userFeeds = await context.UserFeeds
                           .Where(userFeed => userFeed.UserId == currentUser.Id)
                           .Include(u => u.Feed.FeedItems)
                          .ToListAsync();
                    }
                    else
                    {
                        userFeeds = await context.UserFeeds
                         .Where(userFeed => userFeed.UserId == currentUser.Id)
                         .Include(u => u.Feed)
                        .ToListAsync();
                    }

                    List<Feed> feeds = new List<Feed>();
                    foreach (UserFeed userFeed in userFeeds)
                    {
                        feeds.Add(userFeed.Feed);
                    }

                    return feeds;
                }

                return new List<Feed>();
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
