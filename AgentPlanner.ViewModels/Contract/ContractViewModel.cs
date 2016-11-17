using System;

namespace AgentPlanner.ViewModels.Contract
{
    public class ContractViewModel
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte ContractTypeId { get; set; }
        public double BillingRate { get; set; }
        public byte BillingFrequencyId { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public bool NightTimeRateIncrease { get; set; }
        public bool SundayRateIncrease { get; set; }
        public bool PublicHolidayRateIncrease { get; set; }
        public byte AssignmentTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ContractTypeViewModel ContractType { get; set; }
        public BillingFrequencyViewModel BillingFrequency { get; set; }
        public AssignmentTypeViewModel AssignmentType { get; set; }
    }
}
