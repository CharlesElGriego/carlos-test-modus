using DataDB.Data;
using DataDB.Models;
using DataDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Repository
{
    public class FeedRepository : IFeedRepository
    {
        private readonly DataContext _dataContext;

        public FeedRepository()
        {
            _dataContext = new DataContext();
        }

        public List<Feed> GetFeeds()
        {
            return _dataContext.Feeds.ToList();
        }
    }
}
