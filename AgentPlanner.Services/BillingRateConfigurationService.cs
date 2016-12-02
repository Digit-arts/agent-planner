using AgentPlanner.Entities.Billing;
using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;

namespace AgentPlanner.Services
{
    public class BillingRateConfigurationService
    {
        private readonly BillingRateConfigurationRepository _billingRateConfigurationRepository;

        public BillingRateConfigurationService()
        {
            _billingRateConfigurationRepository = new BillingRateConfigurationRepository();
        }

        public BillingRateConfiguration GetBillingRateConfiguration()
        {
            return _billingRateConfigurationRepository.Get().ToDto();
        }
    }
}