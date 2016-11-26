using System;
using AgentPlanner.Entities.Enums;

namespace AgentPlanner.Entities.Contract
{
    public class Contract
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ContractTypes ContractTypeId { get; set; }
        public double BillingRate { get; set; }
        public BillingFrequencies BillingFrequencyId { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public bool NightTimeRateIncrease { get; set; }
        public bool SundayRateIncrease { get; set; }
        public bool PublicHolidayRateIncrease { get; set; }
        public AssignmentTypes AssignmentTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? InvoiceNumber { get; set; }

        public ContractType ContractType { get; set; }
        public BillingFrequency BillingFrequency { get; set; }
        public AssignmentType AssignmentType { get; set; }
        public Client.Site Site { get; set; }
    }
}
