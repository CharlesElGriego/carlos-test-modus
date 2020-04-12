using CarlosTest.Dtos;
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
        Task<List<FeedDto>> GetFeeds(string email);
        Task<List<FeedItemDto>> GetFeedItems(int feedId);
        Task<List<FeedItemDto>> GetFeedItems(string email);
        Task<List<FeedDto>> MyFeeds(string email);
        Task<bool> SuscribeToFeed(int feedId, string email);
    }
}
