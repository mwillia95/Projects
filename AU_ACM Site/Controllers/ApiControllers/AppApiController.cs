using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AU_ACM_Site.Models;

namespace AU_ACM_Site.Controllers.ApiControllers
{
    public class AppApiController : ApiController
    {
        protected const string AppName = "AU_ACM_Site";
        protected readonly DataContext DataContext;

        public AppApiController()
        {
            DataContext = new DataContext();
        }

    }
    
}