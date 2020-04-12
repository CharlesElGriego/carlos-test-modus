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
        Task<List<Feed>> GetFeeds(string email);
        Task<List<FeedItem>> GetFeedItems(int feedId);
        Task<List<Feed>> GetFeedItems(string email, bool withItems);
        Task<UserFeed> SuscribeToFeed(int feedId, string email);
    }
}
