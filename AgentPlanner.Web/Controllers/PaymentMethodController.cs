using System.Web.Http;
using AgentPlanner.Services;
using AgentPlanner.ViewModels.Mappers;
using AgentPlanner.ViewModels.PaymentMethod;

namespace AgentPlanner.Web.Controllers
{
    [RoutePrefix("api/paymentMethod")]
    public class PaymentMethodController : BaseController
    {
        private readonly PaymentMethodService _paymentMethodService;

        public PaymentMethodController()
        {
            _paymentMethodService = new PaymentMethodService();
        }
        [HttpGet]
        [Route("list")]
        public PaymentMethodViewModel[] GetAll()
        {
                return _paymentMethodService.GetPaymentMethods().ToVms();
        }

        [HttpGet]
        [Route("{id:int}")]
        public PaymentMethodViewModel Get(int id)
        {
            return _paymentMethodService.GetPaymentMethod(id).ToVm();
        }
    }
}
