using CarlosTest.Dtos;
using CarlosTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CarlosTest.Controllers
{
    [RoutePrefix("api/feeds")]
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
        public async Task<IHttpActionResult> Get()
        {
            return Json(await _feedService.GetFeeds());
        }

        [Authorize]
        [HttpGet]
        [Route("GetFeedItems")]
        public async Task<IHttpActionResult> GetFeedItems(int feedId)
        {
            return Json(await _feedService.GetFeedItems(feedId));
        }

        [Authorize]
        [HttpGet]
        [Route("GetFeedItems")]
        public async Task<IHttpActionResult> GetFeedItems(string email)
        {
            return Json(await _feedService.GetFeedItems(email));
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
                    errorMessage.Content = new StringContent("User is already subscribed to this feed");
                    throw new HttpResponseException(errorMessage);
                }
            }
            return Ok();
        }

        #endregion
    }
}
