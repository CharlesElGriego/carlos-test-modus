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
        List<Feed> GetFeeds();
    }
}
