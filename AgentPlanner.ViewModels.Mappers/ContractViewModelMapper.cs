using System.Collections.Generic;
using System.Linq;
using AgentPlanner.Entities.Contract;
using AgentPlanner.ViewModels.Contract;

namespace AgentPlanner.ViewModels.Mappers
{
    public static class ContractViewModelMapper
    {
        #region Assignment Type

        public static AssignmentTypeViewModel ToVm(this AssignmentType type)
        {
            return new AssignmentTypeViewModel
            {
                Id = type.Id,
                DefaultBillingRate = type.DefaultBillingRate,
                TypeName = type.TypeName
            };
        }

        public static AssignmentTypeViewModel[] ToVm(this IEnumerable<AssignmentType> types)
        {
            return types.Select(x => x.ToVm()).ToArray();
        }

        #endregion

        #region Billing Frequency

        public static BillingFrequencyViewModel ToVm(this BillingFrequency frequency)
        {
            return new BillingFrequencyViewModel
            {
                Id = frequency.Id,
                Frequency = frequency.Frequency
            };
        }

        public static BillingFrequencyViewModel[] ToVm(this IEnumerable<BillingFrequency> frequencies)
        {
            return frequencies.Select(x => x.ToVm()).ToArray();
        }

        #endregion

        #region Contract Type

        public static ContractTypeViewModel ToVm(this ContractType type)
        {
            return new ContractTypeViewModel
            {
                Id = type.Id,
                TypeName = type.TypeName
            };
        }

        public static ContractTypeViewModel[] ToVm(this IEnumerable<ContractType> types)
        {
            return types.Select(x => x.ToVm()).ToArray();
        }

        #endregion

        #region Contract


        public static ContractViewModel ToVm(this Entities.Contract.Contract contract)
        {
            if (contract == null) return null;
            return new ContractViewModel
            {
                Id = contract.Id,
                AssignmentTypeId = (byte)contract.AssignmentTypeId,
                BillingFrequencyId = (byte)contract.BillingFrequencyId,
                BillingRate = contract.BillingRate,
                Comments = contract.Comments,
                ContractTypeId = (byte)contract.ContractTypeId,
                CreatedDate = contract.CreatedDate,
                EndDate = contract.EndDate,
                IsActive = contract.IsActive,
                ModifiedDate = contract.ModifiedDate,
                NightTimeRateIncrease = contract.NightTimeRateIncrease,
                PublicHolidayRateIncrease = contract.PublicHolidayRateIncrease,
                SiteId = contract.SiteId,
                StartDate = contract.StartDate,
                SundayRateIncrease = contract.SundayRateIncrease,
                InvoiceNumber = contract.InvoiceNumber,
                BillingFrequency = contract.BillingFrequency.ToVm(),
                ContractType = contract.ContractType.ToVm(),
                AssignmentType = contract.AssignmentType.ToVm(),
                Site = contract.Site.ToVm(),
                AssignmentViewModels = contract.Assignments.ToVms(),
            };
        }

        public static ContractViewModel[] ToVm(this IEnumerable<Entities.Contract.Contract> contracts)
        {
            return contracts.Select(x => x.ToVm()).ToArray();
        }
        #endregion
    }
}
