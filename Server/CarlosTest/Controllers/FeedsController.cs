using CarlosTest.App_Start;
using CarlosTest.Dtos;
using CarlosTest.Services;
using DataDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarlosTest.Controllers
{
    [RoutePrefix("api/feeds")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class FeedsController : ApiController
    {
        #region Private Properties
        private readonly IFeedService _feedService;
        #endregion

        #region Constructor
        public FeedsController(IFeedService feedService) : base()
        {
            _feedService = feedService;
        }

        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IHttpActionResult> Get(string email)
        {

            List<Feed> feeds = await _feedService.GetFeeds(email);
            List<FeedDto> feedsDto = new List<FeedDto>();
            AutoMapperWebConfiguration.Mapper.Map(feeds, feedsDto);
            return Ok(feedsDto);
        }

        [Authorize]
        [HttpGet]
        [Route("GetFeedItems")]
        public async Task<IHttpActionResult> GetFeedItems(int feedId)
        {
            List<FeedItem> feedItems = await _feedService.GetFeedItems(feedId);
            List<FeedItemDto> feedItemsDto = new List<FeedItemDto>();
            AutoMapperWebConfiguration.Mapper.Map(feedItems, feedItemsDto);
            return Ok(feedItemsDto);
        }

        [Authorize]
        [HttpGet]
        [Route("GetFeedItems")]
        public async Task<IHttpActionResult> GetFeedItems(string email)
        {
            List<FeedItem> feedItems = await _feedService.GetFeedItems(email);
            List<FeedItemDto> feedItemsDto = new List<FeedItemDto>();
            AutoMapperWebConfiguration.Mapper.Map(feedItems, feedItemsDto);
            return Ok(feedItemsDto);
        }

        [Authorize]
        [HttpGet]
        [Route("myFeeds")]
        public async Task<IHttpActionResult> MyFeeds(string email)
        {
            List<Feed> feedItems = await _feedService.MyFeeds(email);
            List<FeedDto> feedItemsDto = new List<FeedDto>();
            AutoMapperWebConfiguration.Mapper.Map(feedItems, feedItemsDto);
            return Ok(feedItemsDto);
        }

        [Authorize]
        [HttpPost]
        [Route("suscribetofeed")]
        public async Task<IHttpActionResult> SuscribedToFeed([FromBody] UserFeedDto userFeed )
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            try
            {
                var suscribe = await _feedService.SuscribeToFeed(userFeed.FeedId, userFeed.UserEmail);

                if (!suscribe)
                {
                    throw  new HttpResponseException(HttpStatusCode.BadRequest);
                }
                
            }
            catch (HttpResponseException exception)
            {
               int httpStatusCode = (int)exception.Response.StatusCode;

                if (httpStatusCode == (int)HttpStatusCode.BadRequest)
                {
                    HttpResponseMessage errorMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
                    errorMessage.Content = new StringContent("Wrong data");
                    throw new HttpResponseException(errorMessage);
                }
                else if (httpStatusCode == (int)HttpStatusCode.Conflict)
                {
                    HttpResponseMessage errorMessage = new HttpResponseMessage(HttpStatusCode.Conflict);
                    errorMessage.Content = new StringContent("You are already subscribed to this feed");
                    throw new HttpResponseException(errorMessage);
                }
            }
            return Ok(true);
        }

        #endregion
    }
}
