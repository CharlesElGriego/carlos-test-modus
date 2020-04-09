using DataDB.Models;
using DataDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosTest.Services
{
    public class FeedService: IFeedService
    {
        private readonly IFeedRepository _repository;

        public FeedService(IFeedRepository repository)
        {
            _repository = repository;
        }

        public List<Feed> GetFeeds()
        {
            return _repository.GetFeeds();
        }
    }
}