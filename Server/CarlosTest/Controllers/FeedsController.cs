using CarlosTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarlosTest.Controllers
{
    [RoutePrefix("api/feeds")]
    public class FeedsController : ApiController
    {
        private readonly IFeedService _feedService;

        public FeedsController(IFeedService feedService) : base()
        {
            _feedService = feedService;
        }

        // GET: api/Feeds
        public IHttpActionResult Get()
        {
            return Json(_feedService.GetFeeds());
        }

        // GET: api/Feeds/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Feeds
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Feeds/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Feeds/5
        public void Delete(int id)
        {
        }
    }
}
