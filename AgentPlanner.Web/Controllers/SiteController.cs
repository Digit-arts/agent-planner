using System.Web.Http;
using AgentPlanner.BindingModels.Mappers;
using AgentPlanner.BindingModels.Site;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Mappers;
using AgentPlanner.ViewModels.Site;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix(("api/site"))]
    public class SiteController : BaseController
    {
        private readonly SiteService _siteService;

        public SiteController()
        {
            _siteService = new SiteService();
        }

        // GET: api/Site
        [HttpGet]
        [Route("list/{pageSize:int}/{pageNumber:int}")]
        public SiteListViewModel Get(int pageSize, int pageNumber)
        {
            return new SiteListViewModel
            {
                SiteViewModels = _siteService.GetPaginatedSites(pageSize, pageNumber).ToVms(),
                SiteCount = _siteService.GetTotalSiteCount()
            };
        }

        // GET: api/Site/5
        [HttpGet]
        [Route("{id:int}")]
        public SiteViewModel Get(int id)
        {
            return _siteService.GetSite(id).ToVm();
        }

        // POST: api/Site
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(SiteBindingModel site)
        {
            return Ok(_siteService.AddSite(site.ToDto()));
        }

        // PUT: api/Site/5
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Put(int id, SiteBindingModel site)
        {
            return Ok(_siteService.UpdateSite(id, site.ToDto()));
        }

        // DELETE: api/Site/5
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_siteService.DeleteSite(id));
        }

        [HttpGet]
        [Route("codecheck/{code}")]
        public bool CodeCheck(string code)
        {
            return _siteService.CheckSiteCode(code);
        }
    }
}
