using System.Collections.Generic;
using System.Linq;
using AgentPlanner.Entities.Billing;
using AgentPlanner.ViewModels.Billing;

namespace AgentPlanner.ViewModels.Mappers
{
    #region Quotation View Model Mapper

    public static class QuotationViewModelMapper
    {
        public static QuotationViewModel ToVm(this Quotation model)
        {
            if (model == null) return null;
            return new QuotationViewModel
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
                BillingFrequency = model.BillingFrequency.ToVm(),
                ContractType = model.ContractType.ToVm(),
                HoursPerDay = model.HoursPerDay,
                TotalCost = model.TotalCost,
                TotalHours = model.TotalHours,
                Client = model.Client.ToVm(),
                Site = model.Site.ToVm()
            };
        }

        public static QuotationViewModel[] ToVm(this IEnumerable<Quotation> model)
        {
            return model.Select(x => x.ToVm()).ToArray();
        }

        #endregion

        #region BillingRateConfiguration View Model Mapper

        public static BillingRateConfigurationViewModel ToVm(this BillingRateConfiguration billingRateConfiguration)
        {
            if (billingRateConfiguration == null) return null;

            return new BillingRateConfigurationViewModel
            {
                Id = billingRateConfiguration.Id,
                HolidayPercentageIncrease = billingRateConfiguration.HolidayPercentageIncrease,
                NightTimePercentageIncrease = billingRateConfiguration.NightTimePercentageIncrease,
                WeekendPercentageIncrease = billingRateConfiguration.WeekendPercentageIncrease
            };
        }

        public static BillingRateConfigurationViewModel[] ToVms(
            this IEnumerable<BillingRateConfiguration> billingRateConfigurations)
        {
            return  billingRateConfigurations.Select(x => x.ToVm()).ToArray();
        }

        #endregion

        #region PublicHoliday View Model Mapper

        public static PublicHolidayViewModel ToVm(this PublicHoliday publicHoliday)
        {
            if (publicHoliday == null) return null;

            return new PublicHolidayViewModel
            {
                Id = publicHoliday.Id,
                HolidayDate = publicHoliday.HolidayDate
            };
        }

        public static PublicHolidayViewModel[] ToVms(this IEnumerable<PublicHoliday> publicHolidayViewModels)
        {
            return publicHolidayViewModels.Select(x => x.ToVm()).ToArray();
        }

        #endregion
    }
}
