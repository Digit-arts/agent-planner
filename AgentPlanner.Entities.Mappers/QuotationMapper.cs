using System.Collections.Generic;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Entities.Enums;

namespace AgentPlanner.Entities.Mappers
{
    public static class QuotationMapper
    {
        public static Quotation ToDbo(this Billing.Quotation model)
        {
            return new Quotation
            {
                Id = model.Id,
                BillingFrequencyId = (byte) model.BillingFrequencyId,
                BillingRate = model.BillingRate,
                ClientId = model.ClientId,
                ContractTypeId = (byte) model.ContractTypeId,
                DateAdded = model.DateAdded,
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

        public static Billing.Quotation ToDto(this Quotation model)
        {
            if (model == null) return null;
            return new Billing.Quotation
            {
                Id = model.Id,
                BillingFrequencyId = (BillingFrequencies) model.BillingFrequencyId,
                BillingRate = model.BillingRate,
                ClientId = model.ClientId,
                ContractTypeId = (ContractTypes) model.ContractTypeId,
                DateAdded = model.DateAdded,
                EndDate = model.EndDate,
                NightTimeRateIncrease = model.NightTimeRateIncrease,
                PublicHolidayRateIncrease = model.PublicHolidayRateIncrease,
                SiteId = model.SiteId,
                StartDate = model.StartDate,
                SundayRateIncrease = model.SundayRateIncrease,
                BillingFrequency = model.BillingFrequency.ToDto(),
                ContractType = model.ContractType.ToDto(),
                HoursPerDay = model.HoursPerDay,
                TotalCost = model.TotalCost,
                TotalHours = model.TotalHours
            };
        }

        public static Billing.Quotation[] ToDto(this IEnumerable<Quotation> model)
        {
            return model.Select(x => x.ToDto()).ToArray();
        }
    }
}
