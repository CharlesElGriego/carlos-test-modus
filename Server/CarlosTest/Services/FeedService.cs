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

        public async Task<List<FeedDto>> GetFeeds(string email)
        {
            List<Feed> feeds = await _repository.GetFeeds(email);
            List<FeedDto> list = new List<FeedDto>();
            foreach (Feed feed in feeds)
            {
                list.Add(new FeedDto()
                {
                    Id = feed.Id,
                    Name = feed.FeedName,
                    Image = feed.Image,
                    IsSubscribed = feed.IsSubscribed
                });
            }

            return list;
        }

        public async Task<List<FeedItemDto>> GetFeedItems(int feedId)
        {
            List<FeedItem> feedItems = await _repository.GetFeedItems(feedId);
            List<FeedItemDto> list = new List<FeedItemDto>();
            if (feedItems != null)
            {
                foreach (FeedItem feedItem in feedItems)
                {
                    list.Add(new FeedItemDto()
                    {
                        Id = feedItem.Id,
                        Title = feedItem.Title,
                        Content = feedItem.Content,
                        Date = feedItem.Date,
                        ParentName = feedItem.Feed.FeedName
                    });
                }
            }

            return list;
        }

        public async Task<List<FeedItemDto>> GetFeedItems(string email)
        {
            List<Feed> feeds = await _repository.GetFeedItems(email, true);
            
            List<FeedItemDto> list = new List<FeedItemDto>();
            foreach (Feed feed in feeds)
            {
                List<FeedItem> feedItems = feed.FeedItems?.ToList();
                if(feedItems != null)
                {
                    foreach (FeedItem item in feedItems)
                    {
                        list.Add(new FeedItemDto()
                        {
                            Id = item.Id,
                            Content = item.Content,
                            Date = item.Date,
                            ParentName = item.Feed.FeedName,
                            Title = item.Title
                        });
                    }
                }

            }

            return list;
        }

        public async Task<List<FeedDto>> MyFeeds(string email)
        {
            List<Feed> feeds = await _repository.GetFeedItems(email, false);

            List<FeedDto> list = new List<FeedDto>();
            foreach (Feed feed in feeds)
            {
                FeedDto newFeed = new FeedDto();
                newFeed.Name = feed.FeedName;
                newFeed.Id = feed.Id;
                newFeed.Image = feed.Image;
                newFeed.IsSubscribed = true;

                list.Add(newFeed);
            }

            return list;
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