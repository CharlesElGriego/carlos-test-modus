using DataDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosTest.Services
{
    public interface IFeedService
    {
        Task<List<Feed>> GetFeeds(string email);
        Task<List<FeedItem>> GetFeedItems(int feedId);
        Task<List<FeedItem>> GetFeedItems(string email);
        Task<List<Feed>> MyFeeds(string email);
        Task<bool> SuscribeToFeed(int feedId, string email);
    }
}
