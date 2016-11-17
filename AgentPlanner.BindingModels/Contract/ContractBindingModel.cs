using System;

namespace AgentPlanner.BindingModels.Contract
{
    public class ContractBindingModel
    {
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
    }
}
