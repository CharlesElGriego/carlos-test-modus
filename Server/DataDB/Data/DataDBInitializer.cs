using DataDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Data
{
    public class DataDBInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        public DataDBInitializer() :base()
        {
            // CreateDatabaseIfNotExists<DataContext>
        }
        protected override void Seed(DataContext context)
        {
            base.Seed(context);

            #region User
            context.Users.Add(new User() { Id = 1, Email="cnavarro3196@gmail.com",Name="Carlos Navarro",Type= 2,Password= "ALf+7hLcEJtybEO6iJhf4nzoiIPmhWIll3KY8u5nFJox5d/ZYIuebgbot2dNnR75jA==" });
            #endregion

            #region Feed
            List<Feed> feeds = new List<Feed>();
            feeds.Add(new Feed() { Id = 1, FeedName = "Android Police" });
            feeds.Add(new Feed() { Id = 2, FeedName = "9to5 Mac" });
            feeds.Add(new Feed() { Id = 3, FeedName = "9to5 Google" });
            feeds.Add(new Feed() { Id = 4, FeedName = "ComicBook.com" });

            feeds.ForEach(feed => context.Feeds.Add(feed));
            #endregion

            #region FeedItem
            List<FeedItem> feedItems = new List<FeedItem>();
            feedItems.Add(new FeedItem() { Id = 1, FeedId = 1, Title = "Title 1", Content = "Content 1", Date = DateTime.UtcNow });
            feedItems.Add(new FeedItem() { Id = 2, FeedId = 1, Title = "Title 2", Content = "Content 2", Date = DateTime.UtcNow });
            feedItems.Add(new FeedItem() { Id = 3, FeedId = 1, Title = "Title 3", Content = "Content 3", Date = DateTime.UtcNow });

            feedItems.Add(new FeedItem() { Id = 4, FeedId = 2, Title = "Title 1", Content = "Content 1", Date = DateTime.UtcNow });
            feedItems.Add(new FeedItem() { Id = 5, FeedId = 2, Title = "Title 2", Content = "Content 2", Date = DateTime.UtcNow });

            feedItems.ForEach(feedItem => context.FeedItems.Add(feedItem));
            #endregion

            #region UserFeed
            context.UserFeeds.Add(new UserFeed() { Id = 1, FeedId = 1, UserId = 1 });
            #endregion


            context.SaveChanges();
        }
    }
}
