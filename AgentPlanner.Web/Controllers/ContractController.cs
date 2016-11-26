using System.Web.Http;
using AgentPlanner.BindingModels.Contract;
using AgentPlanner.BindingModels.Mappers;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Contract;
using AgentPlanner.ViewModels.Mappers;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix("api/contract")]
    public class ContractController : BaseController
    {
        private readonly ContractService _contractService;

        public ContractController()
        {
            _contractService = new ContractService();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ContractViewModel Get(int id)
        {
            return _contractService.Get(id).ToVm();
        }

        [HttpGet]
        [Route("all/{siteId:int}")]
        public ContractViewModel[] GetAll(int siteId)
        {
            return _contractService.GetAll(siteId).ToVm();
        }
        [HttpGet]
        [Route("list/{siteId:int}/{pageSize:int}/{pageNumber:int}")]
        public ContractViewModelList GetContracts(int siteId, int pageSize, int pageNumber)
        {
            return new ContractViewModelList
            {
                ContractViewModel = _contractService.GetContracts(siteId, pageSize, pageNumber).ToVm(),
                ContractCount = _contractService.GetTotalContractsCount(siteId)
            };
        }

        [HttpPost]
        [Route("")]
        public int CreateContract(ContractBindingModel model)
        {
            return _contractService.AddContract(model.ToDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public int UpdateContract(int id, ContractBindingModel model)
        {
            return _contractService.UpdateContract(id, model.ToDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public int DeleteContract(int id)
        {
            return _contractService.DeleteContract(id);
        }

        [HttpGet]
        [Route("createinvoice/{id:int}")]
        public int CreateContractInvoice(int id)
        {
            return _contractService.CreateInvoiceForContract(id);
        }
    }
}
