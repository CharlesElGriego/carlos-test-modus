using CarlosTest.Dtos;
using DataDB.Models;
using DataDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CarlosTest.Services
{
    public class FeedService: IFeedService
    {
        #region Private Properties
          private readonly IFeedRepository _repository;
        #endregion

        #region Constructor 
        public FeedService(IFeedRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Public Methods

        public async Task<List<Feed>> GetFeeds(string email)
        {
            List<Feed> feeds = await _repository.GetFeeds(email);
            return feeds;
        }

        public async Task<List<FeedItem>> GetFeedItems(int feedId)
        {
            List<FeedItem> feedItems = await _repository.GetFeedItems(feedId);
            return feedItems;
        }

        public async Task<List<FeedItem>> GetFeedItems(string email)
        {
            List<Feed> feeds = await _repository.GetFeedItems(email, true);
            
            List<FeedItem> list = new List<FeedItem>();
            foreach (Feed feed in feeds)
            {
                List<FeedItem> feedItems = feed.FeedItems?.ToList();
                if(feedItems != null)
                {
                    foreach (FeedItem item in feedItems)
                    {
                        list.Add(item);
                    }
                }

            }

            return list;
        }

        public async Task<List<Feed>> MyFeeds(string email)
        {
            List<Feed> feeds = await _repository.GetFeedItems(email, false);
            return feeds;
        }

        public async Task<bool> SuscribeToFeed(int feedId, string email)
        {
            try
            {
                var suscribe = await _repository.SuscribeToFeed(feedId, email);
                if (suscribe == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

        #endregion

    }
}