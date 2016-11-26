using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AgentPlanner.Entities.User;
using AgentPlanner.Web.Models;
using Newtonsoft.Json;

namespace AgentPlanner.Web.Controllers
{
    [Authorize]
    public class BaseController : ApiController
    {
        protected TemplatePath TemplatePath;
        public BaseController()
        {
            TemplatePath = new TemplatePath();
            var paths =
                JsonConvert.DeserializeObject<TemplatePath>(System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/templates.json")));
            TemplatePath.Quotation = HttpContext.Current.Server.MapPath(paths.Quotation);
            TemplatePath.Invoice = HttpContext.Current.Server.MapPath(paths.Invoice);
        }
        protected User LoggedInUser => Models.Utility.GetLoggedInUser();
        protected Guid LoggedInUserId => Models.Utility.GetLoggedInUserId(User);
    }
}
