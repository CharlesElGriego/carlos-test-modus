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
        List<Feed> GetFeeds();
    }
}
