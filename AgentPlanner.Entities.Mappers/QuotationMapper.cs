using System.Collections.Generic;
using System.Linq;
using AgentPlanner.DataAccess;
using AgentPlanner.Entities.Enums;
using BillingRateConfiguration = AgentPlanner.Entities.Billing.BillingRateConfiguration;

namespace AgentPlanner.Entities.Mappers
{
    #region Quotation Mapper

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

        #endregion

        #region BillingRateConfiguration Mapper

        public static BillingRateConfiguration ToDto(this DataAccess.BillingRateConfiguration billingRateConfiguration)
        {
            if (billingRateConfiguration == null) return null;

            return new BillingRateConfiguration
            {
                Id = billingRateConfiguration.Id,
                NightTimePercentageIncrease = billingRateConfiguration.NightTimePercentageIncrease,
                HolidayPercentageIncrease = billingRateConfiguration.HolidayPercentageIncrease,
                WeekendPercentageIncrease = billingRateConfiguration.WeekendPercentageIncrease
            };
        }

        public static BillingRateConfiguration[] ToDtos(
            this IEnumerable<DataAccess.BillingRateConfiguration> billingRateConfigurations)
        {
            return billingRateConfigurations.Select(x => x.ToDto()).ToArray();
        }

        #endregion

        #region PublicHoliday Mapper

        public static Billing.PublicHoliday ToDto(this PublicHoliday publicHoliday)
        {
            if (publicHoliday == null) return null;

            return new Billing.PublicHoliday
            {
                Id = publicHoliday.Id,
                HolidayDate = publicHoliday.HolidayDate
            };
        }

        public static Billing.PublicHoliday[] ToDtos(this IEnumerable<PublicHoliday> publicHolidays)
        {
            return publicHolidays.Select(x => x.ToDto()).ToArray();
        }

        #endregion
    }
}
