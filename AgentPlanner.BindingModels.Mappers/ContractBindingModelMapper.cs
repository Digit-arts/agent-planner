using AgentPlanner.BindingModels.Contract;
using AgentPlanner.Entities.Enums;

namespace AgentPlanner.BindingModels.Mappers
{
    public static class ContractBindingModelMapper
    {
        public static Entities.Contract.Contract ToDto(this ContractBindingModel contract)
        {
            return new Entities.Contract.Contract
            {
                AssignmentTypeId = (AssignmentTypes) contract.AssignmentTypeId,
                BillingFrequencyId = (BillingFrequencies) contract.BillingFrequencyId,
                BillingRate = contract.BillingRate,
                Comments = contract.Comments,
                ContractTypeId = (ContractTypes) contract.ContractTypeId,
                EndDate = contract.EndDate,
                IsActive = contract.IsActive,
                NightTimeRateIncrease = contract.NightTimeRateIncrease,
                PublicHolidayRateIncrease = contract.PublicHolidayRateIncrease,
                SiteId = contract.SiteId,
                StartDate = contract.StartDate,
                SundayRateIncrease = contract.SundayRateIncrease,
            };
        }
    }
}
