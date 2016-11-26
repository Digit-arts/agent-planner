using System;
using AgentPlanner.ViewModels.Client;
using AgentPlanner.ViewModels.Contract;
using AgentPlanner.ViewModels.Site;

namespace AgentPlanner.ViewModels.Billing
{
    public class QuotationViewModel
    {
        public int Id { get; set; }
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
        public DateTime DateAdded { get; set; }

        public double TotalHours { get; set; }
        public double TotalCost { get; set; }
        public string HoursPerDay { get; set; }

        public BillingFrequencyViewModel BillingFrequency { get; set; }
        public ContractTypeViewModel ContractType { get; set; }
        public ClientViewModel Client { get; set; }
        public SiteViewModel Site { get; set; }
    }
}
