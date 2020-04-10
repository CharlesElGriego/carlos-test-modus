using DataDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Repositories
{
    public interface IFeedRepository
    {
        Task<List<Feed>> GetFeeds();
        Task<List<FeedItem>> GetFeedItems(int feedId);
        Task<List<Feed>> GetFeedItems(string email);
        Task<UserFeed> SuscribeToFeed(int feedId, string email);
    }
}
