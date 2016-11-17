using System.Linq;
using System.Web.Http;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Contract;
using AgentPlanner.ViewModels.Mappers;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix("api/billingFrequencyType")]
    public class BillingFrequencyController : BaseController
    {
        private readonly BillingFrequencyService _billingFrequencyService;

        public BillingFrequencyController()
        {
            _billingFrequencyService = new BillingFrequencyService();
        }

        [Route("all")]
        [HttpGet]
        public BillingFrequencyViewModel[] GetAllBillingTypeFrequencies()
        {
            return _billingFrequencyService.GetAllBillingTypes().ToVm().ToArray();
        }

    }
}
