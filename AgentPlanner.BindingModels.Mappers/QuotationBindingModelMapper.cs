using AgentPlanner.BindingModels.Billing;
using AgentPlanner.Entities.Billing;
using AgentPlanner.Entities.Enums;

namespace AgentPlanner.BindingModels.Mappers
{
    public static class QuotationBindingModelMapper
    {
        public static Quotation ToDto(this QuotationBindingModel model)
        {
            if(model == null)return null;
            return new Quotation
            {
                BillingFrequencyId = (BillingFrequencies) model.BillingFrequencyId,
                BillingRate = model.BillingRate,
                ClientId = model.ClientId,
                ContractTypeId = (ContractTypes) model.ContractTypeId,
                EndDate = model.EndDate,
                NightTimeRateIncrease = model.NightTimeRateIncrease,
                PublicHolidayRateIncrease = model.PublicHolidayRateIncrease,
                SiteId = model.SiteId,
                StartDate = model.StartDate,
                SundayRateIncrease = model.SundayRateIncrease,
                HoursPerDay = model.HoursPerDay,
                TotalCost = model.TotalCost,
                TotalHours = model.TotalHours
            };
        }
    }
}
