using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AU_ACM_Site.Models;

namespace AU_ACM_Site.Controllers.ApiControllers
{
    [RoutePrefix("api/" + AppName + "/events")]
    public class EventController : AppApiController
    {
        [Route("getEvents")]
        public IHttpActionResult GetEvents()
        {
            //Pulls events from database and orders by startime
            var events = DataContext.Events.OrderBy(x => x.StartTime).ToList();
            return Ok(events);
        }
    }
}