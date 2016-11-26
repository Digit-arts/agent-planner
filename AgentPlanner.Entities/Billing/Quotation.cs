using System;
using AgentPlanner.Entities.Client;
using AgentPlanner.Entities.Contract;
using AgentPlanner.Entities.Enums;

namespace AgentPlanner.Entities.Billing
{
    public class Quotation
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ContractTypes ContractTypeId { get; set; }
        public double BillingRate { get; set; }
        public BillingFrequencies BillingFrequencyId { get; set; }
        public bool NightTimeRateIncrease { get; set; }
        public bool SundayRateIncrease { get; set; }
        public bool PublicHolidayRateIncrease { get; set; }
        public DateTime DateAdded { get; set; }

        public double TotalHours { get; set; }
        public double TotalCost { get; set; }
        public string HoursPerDay { get; set; }

        public BillingFrequency BillingFrequency { get; set; }
        public Client.Client Client { get; set; }
        public Site Site { get; set; }
        public ContractType ContractType { get; set; }
    }
}
