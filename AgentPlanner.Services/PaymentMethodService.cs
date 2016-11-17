using AgentPlanner.Entities.Client;
using AgentPlanner.Repositories;
using AgentPlanner.Entities.Mappers;

namespace AgentPlanner.Services
{
    public class PaymentMethodService
    {
        private readonly PaymentMethodRepository _paymentRepository;

        public PaymentMethodService()
        {
            _paymentRepository = new PaymentMethodRepository();
        }
        public PaymentMethod[] GetPaymentMethods()
        {
            return _paymentRepository.GetAll().ToDtos();
        }

        public PaymentMethod GetPaymentMethod(int paymentMethodId)
        {
            return _paymentRepository.Get(paymentMethodId).ToDto();
        }
    }
}
