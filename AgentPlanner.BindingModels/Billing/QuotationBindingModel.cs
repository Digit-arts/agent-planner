using System;

namespace AgentPlanner.BindingModels.Billing
{
    public class QuotationBindingModel
    {
        public int SiteId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte ContractTypeId { get; set; }
        public double BillingRate { get; set; }
        public byte BillingFrequencyId { get; set; }
        public bool NightTimeRateIncrease { get; set; }
        public bool SundayRateIncrease { get; set; }
        public bool PublicHolidayRateIncrease { get; set; }

        public double TotalHours { get; set; }
        public double TotalCost { get; set; }
        public string HoursPerDay { get; set; }
    }
}
