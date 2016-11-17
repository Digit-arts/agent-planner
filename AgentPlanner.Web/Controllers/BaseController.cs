using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgentPlanner.Entities.User;

namespace AgentPlanner.Web.Controllers
{
    [Authorize]
    public class BaseController : ApiController
    {
        protected User LoggedInUser => Models.Utility.GetLoggedInUser();
        protected Guid LoggedInUserId => Models.Utility.GetLoggedInUserId(User);
    }
}
