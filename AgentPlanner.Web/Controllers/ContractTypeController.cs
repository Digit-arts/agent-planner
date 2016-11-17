using System.Linq;
using System.Web.Http;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Mappers;
using AgentPlanner.ViewModels.Contract;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix("api/contractType")]
    public class ContractTypeController : BaseController
    {
        private readonly ContractTypeService _contractTypeService;

        public ContractTypeController()
        {
            _contractTypeService = new ContractTypeService();
        }

        [Route("all")]
        [HttpGet]
        public ContractTypeViewModel[] GetAllContractTypes()
        {
            return _contractTypeService.GetAllContractTypes().ToVm().ToArray();
        }
    }
}
