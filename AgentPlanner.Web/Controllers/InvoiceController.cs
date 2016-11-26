using System.Web.Http;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Contract;
using AgentPlanner.ViewModels.Mappers;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix("api/invoice")]
    public class InvoiceController : BaseController
    {
        private readonly ContractService _contractService;

        public InvoiceController()
        {
            _contractService = new ContractService();
        }

        [Route("site/{siteId:int}")]
        public ContractViewModel[] GetAllBySite(int siteId)
        {
            return _contractService.GetContractsAsInvoiceForSite(siteId).ToVm();
        }
    }
}
