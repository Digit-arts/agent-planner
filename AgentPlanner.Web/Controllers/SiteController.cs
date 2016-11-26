using System.Web.Http;
using AgentPlanner.BindingModels.Employee;
using AgentPlanner.BindingModels.Mappers;
using AgentPlanner.BindingModels.Site;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Employee;
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
        public int Post(SiteBindingModel site)
        {
           return _siteService.AddSite(site.ToDto());
        }

        // PUT: api/Site/5
        [HttpPut]
        [Route("{id:int}")]
        public int Put(int id, SiteBindingModel site)
        {
            return _siteService.UpdateSite(id, site.ToDto());
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

        [HttpGet]
        [Route("employeetypes/{siteId:int}")]
        public SiteEmployeeTypeViewModel[] GetSiteEmployeeTypes(int siteId)
        {
            return new SiteEmployeeTypeService().GetSiteEmployeeTypesForSite(siteId).ToVms();
        }

        [HttpPost]
        [Route("employeetypes/{siteId}")]
        public IHttpActionResult AddEmployeeType(int siteId, SiteEmployeeTypeBindingModel[] model)
        {
            return Ok(new SiteEmployeeTypeService().AddSiteEmployeeTypes(siteId, model.ToDtos()));
        }
    }
}
