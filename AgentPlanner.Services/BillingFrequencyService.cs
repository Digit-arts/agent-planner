using AgentPlanner.Entities.Mappers;
using AgentPlanner.Repositories;
using BillingFrequency = AgentPlanner.Entities.Contract.BillingFrequency;

namespace AgentPlanner.Services
{
    public class BillingFrequencyService
    {
        private readonly BillingFrequencyRepository _billingFrequencyRepository;

        public BillingFrequencyService()
        {
            _billingFrequencyRepository = new BillingFrequencyRepository();
        }

        public BillingFrequency[] GetAllBillingTypes()
        {
            return _billingFrequencyRepository.GetAllBillingFrequenciess().ToDto();
        }
    }
}
