using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentPlanner.Entities.Contract;
using AgentPlanner.Entities.Enums;

namespace AgentPlanner.Entities.Mappers
{
    public static class ContractMapper
    {
        #region Assignment Type

        public static AssignmentType ToDto(this DataAccess.AssignmentType type)
        {
            return new AssignmentType
            {
                Id = type.Id,
                DefaultBillingRate = type.DefaultBillingRate,
                TypeName = type.TypeName
            };
        }

        public static AssignmentType[] ToDto(this IEnumerable<DataAccess.AssignmentType> types)
        {
            return types.Select(x => x.ToDto()).ToArray();
        }

        #endregion

        #region Billing Frequency

        public static BillingFrequency ToDto(this DataAccess.BillingFrequency frequency)
        {
            return new BillingFrequency
            {
                Id = frequency.Id,
                Frequency = frequency.Frequency
            };
        }

        public static BillingFrequency[] ToDto(this IEnumerable<DataAccess.BillingFrequency> frequencies)
        {
            return frequencies.Select(x => x.ToDto()).ToArray();
        }

        #endregion

        #region Contract Type

        public static ContractType ToDto(this DataAccess.ContractType type)
        {
            return new ContractType
            {
                Id = type.Id,
                TypeName = type.TypeName
            };
        }

        public static ContractType[] ToDto(this IEnumerable<DataAccess.ContractType> types)
        {
            return types.Select(x => x.ToDto()).ToArray();
        }

        #endregion

        #region Contract

        public static DataAccess.Contract ToDbo(this Contract.Contract contract)
        {
            return new DataAccess.Contract
            {
                Id = contract.Id,
                AssignmentTypeId = (byte) contract.AssignmentTypeId,
                BillingFrequencyId = (byte) contract.BillingFrequencyId,
                BillingRate = contract.BillingRate,
                Comments = contract.Comments,
                ContractTypeId = (byte) contract.ContractTypeId,
                CreatedDate = contract.CreatedDate,
                EndDate = contract.EndDate,
                IsActive = contract.IsActive,
                ModifiedDate = contract.ModifiedDate,
                NightTimeRateIncrease = contract.NightTimeRateIncrease,
                PublicHolidayRateIncrease = contract.PublicHolidayRateIncrease,
                SiteId = contract.SiteId,
                StartDate = contract.StartDate,
                SundayRateIncrease = contract.SundayRateIncrease,
                InvoiceNumber = contract.InvoiceNumber
            };
        }

        public static Contract.Contract ToDto(this DataAccess.Contract contract)
        {
            if (contract == null) return null;
            return new Contract.Contract
            {
                Id = contract.Id,
                AssignmentTypeId = (AssignmentTypes) contract.AssignmentTypeId,
                BillingFrequencyId = (BillingFrequencies) contract.BillingFrequencyId,
                BillingRate = contract.BillingRate,
                Comments = contract.Comments,
                ContractTypeId = (ContractTypes) contract.ContractTypeId,
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
                BillingFrequency = contract.BillingFrequency.ToDto(),
                ContractType = contract.ContractType.ToDto(),
                AssignmentType = contract.AssignmentType.ToDto(),
                Site = contract.Site.ToDto()
            };
        }

        public static Contract.Contract[] ToDto(this IEnumerable<DataAccess.Contract> contracts)
        {
            return contracts.Select(x => x.ToDto()).ToArray();
        }
        #endregion
    }
}
